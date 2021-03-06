using System.Threading.Tasks;

namespace Students.Domain.AggregatesModel.UserAggregate
{
    public interface IUserCommands
    {
        Task AddUserAsync(string userName);
        
        void UpdateUser(string userName,int userId);
        
        void DeleteUser(User user);
        
        Task AddLessonToUserAsync(int userId, int lessonId);

        Task AddRoleToUserAsync(int userId, int roleId);
        
        void RemoveLessonFromUser(int userId, int lessonId);
        
        void RemoveRoleFromUser(int userId, int roleId);
    }
}