
namespace SpiderNetwork.Client
{
    public class StatusHostedService : BackgroundService
    {
        private readonly PeriodicTimer _timer;
        private ILogger<StatusHostedService> _logger;
        private readonly ServerManager _serverManager;

        public StatusHostedService(ILogger<StatusHostedService> logger, ServerManager serverManager)
        {
            _logger = logger;
            _serverManager = serverManager;
            _timer = new PeriodicTimer(TimeSpan.FromSeconds(10));
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("{Name} is starting.", nameof(StatusHostedService));

            cancellationToken.Register(() => _logger.LogInformation("{Name} is stopping.", nameof(StatusHostedService)));

            while (await _timer.WaitForNextTickAsync(cancellationToken))
            {
                _serverManager.SendStatus();
            }
        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            _timer.Dispose();
            await base.StopAsync(cancellationToken);
        }
    }
}
