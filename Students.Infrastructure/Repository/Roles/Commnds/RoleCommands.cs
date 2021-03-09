using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
            await _context.Roles.AddAsync(new Role(roleTitle));
        }

        public async Task RemoveRoleAsync(int roleId)
        {
            _context.Roles.Remove(await _context.Roles.FirstAsync(r => r.Id == roleId));
        }

        public async Task UpdateRoleAsync(int roleId, string roleTitle)
        {
            Role role =await _context.Roles.FirstAsync(r=>r.Id == roleId);
            role = role.updateRoleTitle(role,roleTitle);
            _context.Roles.Update(role);
        }
    }
}