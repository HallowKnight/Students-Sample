using System.Threading.Tasks;

namespace Students.Domain.AggregatesModel.LessonAggregate
{
    public interface ILessonCommands
    {
        Task AddLessonAsync(Lesson lesson);
        
        void UpdateLesson(Lesson lesson);
        
        void DeleteLessons(Lesson lesson);
    }
}