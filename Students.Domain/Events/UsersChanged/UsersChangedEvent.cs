using MediatR;
using Students.Domain.AggregatesModel.UserAggregate;
using Students.Domain.Common;

namespace Students.Domain.Events.UsersChanged
{
    public class UsersChangedEvent : DomainEvent ,INotification 
    {
        
        
        public User User {  get; }

        
        
    }
}