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
        
        public async Task AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }
   
        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
        }
        
        public void DeleteUser(User user)
        {
            _context.Users.Remove(user);
        }
        
        public async Task AddLessonToUserAsync(int userId, int lessonId)
        {
            User user =await _context.Users.FirstAsync(u => u.Id == userId);
            var ul = user.UserLesson(userId, lessonId);

           await _context.UserLessons.AddAsync(ul);
        }

        public async Task AddRoleToUserAsync(int userId, int roleId)
        {
            User user = _context.Users.First(u => u.Id == userId);
            await _context.UserRoles.AddAsync(user.UserRole(userId, roleId));
        }

        public void RemoveLessonFromUser(int userId, int lessonId)
        {
            UserLessons userLesson = _context.UserLessons.First(ul => ul.LessonId == lessonId && ul.UserId == userId);
            _context.UserLessons.Remove(userLesson);
        }

        public void RemoveRoleFromUser(int userId, int roleId)
        {
            UserRoles userRole = _context.UserRoles.First(ur=>ur.UserId == userId && ur.RoleId == roleId);
            _context.UserRoles.Remove(userRole);
        }
    }
}