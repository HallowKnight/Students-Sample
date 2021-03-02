using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Students.Application.Common.Event;
using Students.Domain.Events;

namespace Students.Application.Users.EventHandlers
{
    public class UsersChangedEventHandler : INotificationHandler<DomainEventNotifications<UsersChangedEvent>>
    {
        public Task Handle(DomainEventNotifications<UsersChangedEvent> notification, CancellationToken cancellationToken)
        {
            
            return Task.CompletedTask;
        }
    }
}