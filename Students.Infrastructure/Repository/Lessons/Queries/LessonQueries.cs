using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Students.Domain.AggregatesModel.LessonAggregate;
using Students.Infrastructure.Persistence.DBContext;

namespace Students.Infrastructure.Repository.Lessons.Queries
{
    public class LessonQueries : ILessonQueries
    {
        
        private readonly StudentsDbContext _context;
        public LessonQueries(StudentsDbContext context)
        {
            _context = context;
        }

        public async Task<List<Lesson>> GetAllLessonsAsync()
        {
            return await _context.Lessons.ToListAsync();
        }

        public async Task<Lesson> GetLessonByIdAsync(int lessonId)
        {
            return await _context.Lessons.SingleOrDefaultAsync(l => l._Id == lessonId);
        }
        
        public async Task<List<string>>  GetUserLessonsAsync(int userId)
        {

            List<string> lessonsTitles = await _context.UserLessons.Where(ul => ul.UserId == userId)
                .Select(ul => ul.Lesson.LessonTitle).ToListAsync();
            return lessonsTitles;
        }

    }
}