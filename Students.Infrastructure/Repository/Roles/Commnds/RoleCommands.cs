using System.Linq;
using System.Threading.Tasks;
using Students.Domain.AggregatesModel.RoleAggregate;
using Students.Infrastructure.Persistence.DBContext;

namespace Students.Infrastructure.Repository.Roles.Commnds
{
    public class RoleCommands : IRoleCommands
    {
        private readonly StudentsDbContext _context;

        public RoleCommands(StudentsDbContext context)
        {
            _context = context;
        }


        public async Task AddRoleAsync(string roleTitle)
        {
            await _context.Roles.AddAsync(new Role() {RoleTitle = roleTitle});
        }

        public void RemoveRole(int roleId)
        {
            _context.Roles.Remove(_context.Roles.First(r => r.Id == roleId));
        }

        public void UpdateRole(int roleId, string roleTitle)
        {
            Role oldRole = _context.Roles.First(r=>r.Id == roleId);
            oldRole.RoleTitle = roleTitle;
            _context.Roles.Update(oldRole);
        }
    }
}