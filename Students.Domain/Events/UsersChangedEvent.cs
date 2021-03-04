using MediatR;
using Students.Domain.AggregatesModel.UserAggregate;
using Students.Domain.Common;

namespace Students.Domain.Events
{
    public class UsersChangedEvent : DomainEvent ,INotification
    {
    
        
         public UsersChangedEvent(User user)
        {
            User = user;
        }
        
        public User User { get; }
        
    }
}