using System.Threading.Tasks;

namespace Students.Domain.AggregatesModel.SchoolAggregate
{
    public interface ISchoolCommands
    {
        Task CreateSchoolAsync(string schoolTitle);

        Task DeleteSchoolAsync(int schoolId);

        Task UpdateSchoolAsync(int schoolId, string schoolTitle);

        Task CreateClassAsync(string classTitle,int schoolId);

        Task UpdateClassAsync(int classId,string classTitle);
        
        Task DeleteClassAsync(int classId);


    }
}