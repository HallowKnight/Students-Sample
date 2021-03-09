using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Students.Domain.AggregatesModel.LessonAggregate;
using Students.Infrastructure.Persistence.DBContext;

namespace Students.Infrastructure.Repository.Lessons.Commands
{
    public class LessonCommands : ILessonCommands
    {
        
        private readonly StudentsDbContext _context;

        public LessonCommands(StudentsDbContext context)
        {
            _context = context;
        }
        
        public async Task AddLessonAsync(string lessonTitle)
        {
            await _context.Lessons.AddAsync(new Lesson(lessonTitle));
        }

        public async Task UpdateLessonAsync(int lessonId,string lessonTitle)
        {
            Lesson lesson = await _context.Lessons.FirstOrDefaultAsync(l => l.Id == lessonId);
            lesson = lesson.UpdateLessonTitle(lesson, lessonTitle);
            _context.Lessons.Update(lesson);
        }

        public async Task DeleteLessonAsync(int lessonId)
        {
            _context.Lessons.Remove(await _context.Lessons.FirstOrDefaultAsync(l => l.Id == lessonId));
        }


    }
}