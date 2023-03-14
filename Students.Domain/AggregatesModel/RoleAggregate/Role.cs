using System.Collections.Generic;
using Students.Domain.AggregatesModel.UserAggregate;
using Students.Domain.Common;

namespace Students.Domain.AggregatesModel.RoleAggregate;

public class Role : Entity, IAggregateRoot
{
    #region Contsructor

    public Role(string roleTitle)
    {
        RoleTitle = roleTitle;
    }

    #endregion

    public string RoleTitle { get; private set; }

    #region Relation

    public List<UserRoles> UserRoles { get; private set; }

    #endregion

    #region Helpers and Validators

    public Role NewRole(string roleTitle)
    {
        return new Role(roleTitle)
        {
            RoleTitle = roleTitle
        };
    }

    public Role updateRoleTitle(Role role, string newtitle)
    {
        role.RoleTitle = newtitle;
        return role;
    }

    #endregion
}