using MediatR;
using Students.Domain.Common;

namespace Students.Application.Common.Event
{
    
    // Used To Trigger The Notification Handler After Some Changes Applied to the Database in the Handlers
    public class DomainEventNotifications<TDomainEvent> : INotification where TDomainEvent : DomainEvent 
    {
        
        public DomainEventNotifications(TDomainEvent domainEvent)
        {
            DomainEvent = domainEvent;
        }
        
        public TDomainEvent DomainEvent { get; }
    }
}