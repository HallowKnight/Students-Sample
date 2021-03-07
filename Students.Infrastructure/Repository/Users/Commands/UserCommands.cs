using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Students.Domain.AggregatesModel.UserAggregate;
using Students.Infrastructure.Persistence.DBContext;

namespace Students.Infrastructure.Repository.Users.Commands
{
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
            User user = await _context.Users.FirstOrDefaultAsync(u => u._Id == userId);
            user = user.UpdateUser(user, userName);
            _context.Users.Update(user);
        }

        public async Task DeleteUserAsync(int userId)
        {
            _context.Users.Remove(await _context.Users.FirstOrDefaultAsync(u => u._Id == userId));
        }

        public async Task AddLessonToUserAsync(int userId, int lessonId)
        {
            User user = await _context.Users.FirstAsync(u => u._Id == userId);
            await _context.UserLessons.AddAsync(user.UserLesson(userId, lessonId));
        }

        public async Task AddRoleToUserAsync(int userId, int roleId)
        {
            User user = _context.Users.First(u => u._Id == userId);
            await _context.UserRoles.AddAsync(user.UserRole(userId, roleId));
        }

        public async Task RemoveLessonFromUserAsync(int userId, int lessonId)
        {
            UserLessons userLesson =
                await _context.UserLessons.FirstAsync(ul => ul.LessonId == lessonId && ul.UserId == userId);
            _context.UserLessons.Remove(userLesson);
        }

        public async Task RemoveRoleFromUserAsync(int userId, int roleId)
        {
            UserRoles userRole = await _context.UserRoles.FirstAsync(ur => ur.UserId == userId && ur.RoleId == roleId);
            _context.UserRoles.Remove(userRole);
        }
    }
}