using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Students.Domain.AggregatesModel.UserAggregate;
using Students.Infrastructure.Persistence.DBContext;

namespace Students.Infrastructure.Repository.Users.Commands;

public class UserCommands : IUserCommands
{
    private readonly StudentsDbContext _context;

    public UserCommands(StudentsDbContext context)
    {
        _context = context;
    }

    public async Task AddUserAsync(string userName)
    {
        await _context.Users.AddAsync(new User(userName, null));
    }

    public async Task UpdateUserAsync(string userName, int userId)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
        user = user.UpdateUser(user, userName);
        _context.Users.Update(user);
    }

    public async Task DeleteUserAsync(int userId)
    {
        _context.Users.Remove(await _context.Users.FirstOrDefaultAsync(u => u.Id == userId));
    }

    public async Task AddLessonToUserAsync(int userId, int lessonId)
    {
        var user = await _context.Users.FirstAsync(u => u.Id == userId);
        await _context.UserLessons.AddAsync(user.UserLesson(userId, lessonId));
    }

    public async Task AddRoleToUserAsync(int userId, int roleId)
    {
        var user = _context.Users.First(u => u.Id == userId);
        await _context.UserRoles.AddAsync(user.UserRole(userId, roleId));
    }

    public async Task RemoveLessonFromUserAsync(int userId, int lessonId)
    {
        var userLesson =
            await _context.UserLessons.FirstAsync(ul => ul.LessonId == lessonId && ul.UserId == userId);
        _context.UserLessons.Remove(userLesson);
    }

    public async Task RemoveRoleFromUserAsync(int userId, int roleId)
    {
        var userRole = await _context.UserRoles.FirstAsync(ur => ur.UserId == userId && ur.RoleId == roleId);
        _context.UserRoles.Remove(userRole);
    }
}