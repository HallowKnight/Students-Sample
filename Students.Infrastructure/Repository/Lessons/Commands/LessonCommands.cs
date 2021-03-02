using System.Threading.Tasks;
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
        
        public async Task AddLessonAsync(Lesson lesson)
        {
            await _context.Lessons.AddAsync(lesson);
        }

        public void UpdateLesson(Lesson lesson)
        {
            _context.Lessons.Update(lesson);
        }

        public void DeleteLessons(Lesson lesson)
        {
            _context.Lessons.Remove(lesson);
        }

      
    }
}