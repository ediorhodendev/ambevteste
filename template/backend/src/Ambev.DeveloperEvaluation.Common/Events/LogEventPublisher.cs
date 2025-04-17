using Ambev.DeveloperEvaluation.Common.Events;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Infrastructure.Events
{
    public class LogEventPublisher : IEventPublisher
    {
        private readonly ILogger<LogEventPublisher> _logger;

        public LogEventPublisher(ILogger<LogEventPublisher> logger)
        {
            _logger = logger;
        }

        public Task PublishAsync<T>(T eventData, string eventName, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("[EVENTO] {EventName}: {@Data}", eventName, eventData);
            return Task.CompletedTask;
        }
    }
}