using System.Collections.Generic;
using System.Threading.Tasks;

namespace Students.Domain.AggregatesModel.SchoolAggregate
{
    public interface ISchoolQueries
    {
        Task<List<School>> GetAllSchoolsAsync();

        Task<School> GetSchoolByIdAsync(int schoolId);

        Task<Class> GetClassByIdAsync(int classId);

        Task<List<Class>> GetSchoolClassesAsync(int schoolId);

        Task<List<Class>> GetAllClassesAsync();
    }
}