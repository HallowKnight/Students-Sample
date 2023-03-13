using System.Threading.Tasks;
using Students.Domain.Common;
using Students.Infrastructure.Persistence.DBContext;

namespace Students.Infrastructure.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StudentsDbContext _context;


        public UnitOfWork(StudentsDbContext context)
        {
            _context = context;
        }


        public int SaveChanges()
        {
            _context.SaveChanges();
            return _context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}