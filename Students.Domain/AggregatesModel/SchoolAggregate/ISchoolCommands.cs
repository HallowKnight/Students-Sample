using System.Threading.Tasks;

namespace Students.Domain.AggregatesModel.SchoolAggregate
{
    public interface ISchoolCommands
    {
        Task CreateSchoolAsync(string schoolTitle);

        void DeleteSchool(int schoolId);

        void UpdateSchool(int schoolId, string schoolTitle);

        Task CreateClassAsync(string classTitle,int schoolId);

        void UpdateClass(int classId,string classTitle);
        
        void DeleteClass(int classId);


    }
}