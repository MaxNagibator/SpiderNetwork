
namespace SpiderNetwork.Server
{
    public class ClientsKeeper
    {
        public List<Client> Clients { get; set; }

        private object _lock = new object();

        public void AddClient(int id, ClientStatus status)
        {
            lock (_lock)
            {
                if (Clients == null)
                {
                    Clients = new List<Client>();
                }
                var client = Clients.FirstOrDefault(x => x.Id == id);
                if (client == null)
                {
                    client = new Client() { Id = id };
                    Clients.Add(client);
                }
                client.LastOnlineDate = DateTime.UtcNow;
                client.Status = status;
            }
        }
    }

    public class Client
    {
        public int Id { get; set; }
        public ClientStatus Status { get; set; }
        public DateTime LastOnlineDate { get; set; }
    }

    public enum ClientStatus
    {
        Stop = 0,
        Run = 1,
        LongTimeNotResponsed = 2,
    }
}
