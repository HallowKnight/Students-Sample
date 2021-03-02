using System.Collections.Generic;
using Students.Domain.AggregatesModel.UserAggregate;
using Students.Domain.Common;

namespace Students.Domain.AggregatesModel.RoleAggregate
{
    public class Role :  Entity,IAggregateRoot
    {
        public string RoleTitle { get; set; }
        
        
        public List<UserRoles> UserRoles { get; set; }



        public Role NewRole(string roleTitle)
        {
            return new Role()
            {
                RoleTitle = roleTitle
            };
        }
        
    }
}