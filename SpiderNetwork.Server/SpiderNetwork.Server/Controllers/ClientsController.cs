using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace SpiderNetwork.Server.Controllers
{
    /// <summary>
    /// Контроллер для клиентов.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly ILogger<ClientsController> _logger;
        private readonly ClientsKeeper _keeper;

        public ClientsController(ILogger<ClientsController> logger, ClientsKeeper keeper)
        {
            _logger = logger;
            _keeper = keeper;
        }

        [HttpPost]
        [Route("SetStatus")]
        public void SetStatus(int clientId, ClientStatus status)
        {
            _keeper.AddClient(clientId, status);
        }

        [HttpPost]
        [Route("GiveMeTaskBro")]
        public void GiveMeTaskBro(int clientId)
        {
            // _keeper.AddClient(clientId, status);
        }
    }
}
