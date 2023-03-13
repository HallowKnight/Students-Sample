using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Students.Domain.AggregatesModel.SchoolAggregate;
using Students.Infrastructure.Persistence.DBContext;

namespace Students.Infrastructure.Repository.Schools.Queries
{
    public class SchoolQueries : ISchoolQueries
    {
        private readonly StudentsDbContext _context;

        public SchoolQueries(StudentsDbContext context)
        {
            _context = context;
        }

        public async Task<List<School>> GetAllSchoolsAsync()
        {
            return await _context.Schools.ToListAsync();
        }

        public async Task<School> GetSchoolByIdAsync(int schoolId)
        {
            return await _context.Schools.FirstAsync(s => s.Id == schoolId);
        }

        public async Task<Class> GetClassByIdAsync(int classId)
        {
            return await _context.Classes.FirstAsync(c => c.Id == classId);
        }

        public async Task<List<Class>> GetSchoolClassesAsync(int schoolId)
        {
            return await _context.Classes.Where(c => c.SchoolId == schoolId).ToListAsync();
        }

        public async Task<List<Class>> GetAllClassesAsync()
        {
            return await _context.Classes.ToListAsync();
        }
    }
}