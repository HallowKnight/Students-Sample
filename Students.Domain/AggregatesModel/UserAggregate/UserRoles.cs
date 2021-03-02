using Students.Domain.AggregatesModel.RoleAggregate;
using Students.Domain.Common;

namespace Students.Domain.AggregatesModel.UserAggregate
{
    public class UserRoles : Entity
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        
      
        
        
        public User User { get; set; }
        
        public Role Role { get; set; }
    }
}