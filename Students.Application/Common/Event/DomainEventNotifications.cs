using MediatR;
using Students.Domain.Common;

namespace Students.Application.Common.Event
{
    public class DomainEventNotifications<TDomainEvent> : INotification where TDomainEvent : DomainEvent 
    {
        
        public DomainEventNotifications(TDomainEvent domainEvent)
        {
            DomainEvent = domainEvent;
        }
        
        public TDomainEvent DomainEvent { get; }
    }
}