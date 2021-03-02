using System.Threading.Tasks;

namespace Students.Domain.Common
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
        int SaveChanges();
    }
}
