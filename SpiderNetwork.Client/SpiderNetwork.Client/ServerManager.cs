
namespace SpiderNetwork.Client
{
    public class ServerManager
    {
        private readonly HttpClient _client = new() { BaseAddress = new Uri("http://localhost:5022/") };

        public async Task SendStatus()
        {
            try
            {
                var response = await _client.PostAsJsonAsync<object?>($"Clients/SetStatus?clientId={Globals.Settings.ClientId}&status={(int)ClientStatus.Run}", null);
                if (response.IsSuccessStatusCode == false)
                    throw new HttpRequestException($"Не смогли отправить запрос - {response.StatusCode}");
                //var result = await response.Content.ReadFromJsonAsync<GazpromNeftDto.Root>();
                //if (result is null || result.Data is null)
                //    throw new NullReferenceException("Сервер вернул пустоту");
                Console.WriteLine("ping pong");
            }
            catch (Exception ex)
            {
                // todo logs
                Console.WriteLine(ex.Message);
            }
        }

        public enum ClientStatus
        {
            Stop = 0,
            Run = 1,
        }
    }
}
