using Students.Domain.AggregatesModel.LessonAggregate;
using Students.Domain.Common;

namespace Students.Domain.AggregatesModel.UserAggregate
{
    public class UserLessons : Entity 
    {
        
        public Lesson Lesson { get; set; }

        public int UserId { get; set; }
        public int LessonId { get; set; }
        
        public User User { get; set; }
    }
}