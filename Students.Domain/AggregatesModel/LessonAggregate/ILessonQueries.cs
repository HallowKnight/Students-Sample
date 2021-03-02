using System.Collections.Generic;
using System.Threading.Tasks;

namespace Students.Domain.AggregatesModel.LessonAggregate
{
    public interface ILessonQueries
    {

        Task<List<Lesson>> GetAllLessonsAsync();
        
        Task<Lesson> GetLessonByIdAsync(int lessonId);
        
        Lesson GetLessonById(int lessonId);

        Task<List<string>> GetUserLessonsAsync(int userId);

      
    }
}