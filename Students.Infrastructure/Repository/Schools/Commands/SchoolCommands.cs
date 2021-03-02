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
            await _context.Schools.AddAsync(new School() {SchoolTitle = schoolTitle});
        }

        public void DeleteSchool(int schoolId)
        {
            School school = _context.Schools.First(s => s.Id == schoolId);
            _context.Remove(school);
        }

        public void UpdateSchool(int schoolId, string schoolTitle)
        {
            School school = _context.Schools.First(s => s.Id == schoolId);
            school.SchoolTitle = schoolTitle;
            _context.Schools.Update(school);
        }

        public async Task CreateClassAsync(string classTitle,int schoolId)
        {
            await _context.AddAsync(_context.Schools.First(s=>s.Id == schoolId).NewClass(classTitle,schoolId));
        }

        public void UpdateClass(int classId,string classTitle)
        {
            var newClass = _context.Classes.First(c => c.Id == classId);
            newClass.ClassTitle = classTitle;
            _context.Classes.Update(newClass);
        }   

        public void DeleteClass(int classId)
        {
            _context.Remove(_context.Classes.First(c => c.Id == classId));
        }
    }
}