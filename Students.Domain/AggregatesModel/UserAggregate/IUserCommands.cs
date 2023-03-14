using System.Threading.Tasks;

namespace Students.Domain.AggregatesModel.UserAggregate;

public interface IUserCommands
{
    Task AddUserAsync(string userName);

    Task UpdateUserAsync(string userName, int userId);

    Task DeleteUserAsync(int userId);

    Task AddLessonToUserAsync(int userId, int lessonId);

    Task AddRoleToUserAsync(int userId, int roleId);

    Task RemoveLessonFromUserAsync(int userId, int lessonId);

    Task RemoveRoleFromUserAsync(int userId, int roleId);
}