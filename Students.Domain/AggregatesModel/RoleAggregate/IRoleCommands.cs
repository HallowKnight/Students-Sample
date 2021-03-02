using System.Threading.Tasks;

namespace Students.Domain.AggregatesModel.RoleAggregate
{
    public interface IRoleCommands
    {
        Task AddRoleAsync(string roleTitle);

        void RemoveRole(int roleId);

        void UpdateRole(int roleId, string roleTitle);
    }
}