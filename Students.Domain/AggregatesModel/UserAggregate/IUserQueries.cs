using System.Collections.Generic;
using System.Threading.Tasks;

namespace Students.Domain.AggregatesModel.UserAggregate
{
    public interface IUserQueries
    {
        Task<User> GetUserByIdAsync(int userId);
        
        Task<List<User>> GetAllUsersAsync();
    }
}