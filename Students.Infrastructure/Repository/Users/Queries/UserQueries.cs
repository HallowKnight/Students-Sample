using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Students.Domain.AggregatesModel.UserAggregate;
using Students.Infrastructure.Persistence.DBContext;

namespace Students.Infrastructure.Repository.Users.Queries
{
    public class UserQueries : IUserQueries
    {
        private readonly StudentsDbContext _context;

        public UserQueries(StudentsDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Id == userId);
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }
    }
}