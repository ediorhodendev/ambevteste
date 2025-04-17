using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Common.Events
{
    
        public interface IEventPublisher
        {
            Task PublishAsync<T>(T eventData, string eventName, CancellationToken cancellationToken = default);
        }
    
}
