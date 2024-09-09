using Microsoft.AspNetCore.Mvc;

namespace SpiderNetwork.Server.Controllers
{
    /// <summary>
    ///  онтроллер дл€ отображени€ здоровь€ клиентов.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class HealthController : ControllerBase
    {
        private readonly ILogger<ClientsController> _logger;
        private readonly ClientsKeeper _keeper;

        public HealthController(ILogger<ClientsController> logger, ClientsKeeper keeper)
        {
            _logger = logger;
            _keeper = keeper;
        }

        [HttpGet(Name = "Status")]
        public object Status()
        {
            return _keeper.Clients.Select(x => new //ApiModel
            {
                Id = x.Id,
                Status = x.Status,
            });
        }
    }
}
