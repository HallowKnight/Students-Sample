using Students.Domain.AggregatesModel.RoleAggregate;
using Students.Domain.Common;

namespace Students.Domain.AggregatesModel.UserAggregate;

public class UserRoles : Entity
{
    #region Constructor

    public UserRoles(int userId, int roleId)
    {
        UserId = userId;
        RoleId = roleId;
    }

    #endregion

    public int UserId { get; }

    public int RoleId { get; }

    #region Relations

    public User User { get; private set; }

    public Role Role { get; private set; }

    #endregion
}