using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Students.Domain.AggregatesModel.RoleAggregate;
using Students.Domain.AggregatesModel.UserAggregate;
using Students.Infrastructure.Persistence.DBContext;

namespace Students.Infrastructure.Repository.Roles.Queries;

public class RoleQueries : IRoleQueries
{
    private readonly StudentsDbContext _context;

    public RoleQueries(StudentsDbContext context)
    {
        _context = context;
    }

    public async Task<Role> GetRoleByIdAsync(int roleId)
    {
        return await _context.Roles.FirstAsync(r => r.Id == roleId);
    }

    public async Task<List<Role>> GetAllRolesAsync()
    {
        return await _context.Roles.ToListAsync();
    }

    public async Task<List<User>> GetRoleUsersAsync(int roleId)
    {
        return await _context.UserRoles.Where(ur => ur.RoleId == roleId).Select(ur => ur.User).ToListAsync();
    }

    public async Task<List<Role>> GetUserRolesAsync(int userId)
    {
        return await _context.UserRoles.Where(ur => ur.UserId == userId).Select(ur => ur.Role).ToListAsync();
    }
}