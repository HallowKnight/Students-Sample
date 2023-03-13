using System.Collections.Generic;
using System.Threading.Tasks;
using Students.Domain.AggregatesModel.UserAggregate;

namespace Students.Domain.AggregatesModel.RoleAggregate
{
    public interface IRoleQueries
    {
        Task<Role> GetRoleByIdAsync(int roleId);

        Task<List<Role>> GetAllRolesAsync();

        Task<List<User>> GetRoleUsersAsync(int roleId);

        Task<List<Role>> GetUserRolesAsync(int userId);
    }
}