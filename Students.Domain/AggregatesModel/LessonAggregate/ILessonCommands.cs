using System.Threading.Tasks;

namespace Students.Domain.AggregatesModel.LessonAggregate
{
    public interface ILessonCommands
    {
        Task AddLessonAsync(string lessonTitle);
        
        Task UpdateLessonAsync(int lessonId,string lessonTitle);
        
        Task DeleteLessonAsync(int lessonId);
    }
}