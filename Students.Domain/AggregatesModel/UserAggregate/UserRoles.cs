using Students.Domain.AggregatesModel.RoleAggregate;
using Students.Domain.Common;

namespace Students.Domain.AggregatesModel.UserAggregate
{
    public class UserRoles : Entity
    {
        #region Constructor
        
        public UserRoles( int userId, int roleId) 
        {
            _userId = userId;
            _roleId = roleId;
        }
        
        #endregion
        
        public int UserId => _userId;
        private int _userId;

        public int RoleId => _roleId;
        private int _roleId;
        
        #region Relations

        public User User { get; private set; }

        public Role Role { get; private set; }

        #endregion
    }
}