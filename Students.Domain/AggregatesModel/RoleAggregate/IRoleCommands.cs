using System.Threading.Tasks;

namespace Students.Domain.AggregatesModel.RoleAggregate;

public interface IRoleCommands
{
    Task AddRoleAsync(string roleTitle);

    Task RemoveRoleAsync(int roleId);

    Task UpdateRoleAsync(int roleId, string roleTitle);
}