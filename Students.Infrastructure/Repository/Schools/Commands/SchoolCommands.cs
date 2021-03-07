using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Students.Domain.AggregatesModel.SchoolAggregate;
using Students.Infrastructure.Persistence.DBContext;

namespace Students.Infrastructure.Repository.Schools.Commands
{
    public class SchoolCommands : ISchoolCommands
    {

        private readonly StudentsDbContext _context;

        public SchoolCommands(StudentsDbContext context)
        {
            _context = context;
        }
        
        public async Task CreateSchoolAsync(string schoolTitle)
        {
            await _context.Schools.AddAsync(new School(schoolTitle));
        }

        public async Task DeleteSchoolAsync(int schoolId)
        {
            School school =await _context.Schools.FirstAsync(s => s._Id == schoolId);
            _context.Remove(school);
        }

        public async Task UpdateSchoolAsync(int schoolId, string schoolTitle)
        {
            School school =await _context.Schools.FirstAsync(s => s._Id == schoolId);
            school = school.UpdateSchoolTitle(school,schoolTitle);
            _context.Schools.Update(school);
        }

        public async Task CreateClassAsync(string classTitle,int schoolId)
        {
            await _context.AddAsync(_context.Schools.First(s=>s._Id == schoolId).NewClass(classTitle,schoolId));
        }

        public async Task UpdateClassAsync(int classId,string classTitle)
        {
            Class updatingClass =await _context.Classes.FirstAsync(c => c._Id == classId);
            updatingClass = updatingClass.UpdateClassTitle(updatingClass, classTitle);
            _context.Classes.Update(updatingClass);
        }   

        public async Task DeleteClassAsync(int classId)
        {
            _context.Remove(await _context.Classes.FirstAsync(c => c._Id == classId));
        }
    }
}