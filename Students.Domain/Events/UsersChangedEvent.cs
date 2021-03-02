using Students.Domain.AggregatesModel.UserAggregate;
using Students.Domain.Common;

namespace Students.Domain.Events
{
    public class UsersChangedEvent : DomainEvent
    {
    
        public UsersChangedEvent(User user)
        {
            User = user;
        }
        
        public User User { get; }
        
    }
}