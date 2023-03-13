using Students.Domain.AggregatesModel.LessonAggregate;
using Students.Domain.Common;

namespace Students.Domain.AggregatesModel.UserAggregate
{
    public class UserLessons : Entity
    {
        #region Constructor

        public UserLessons(int userId, int lessonId)
        {
            UserId = userId;
            LessonId = lessonId;
        }

        #endregion

        public int UserId { get; }

        public int LessonId { get; }

        #region Relations

        public Lesson Lesson { get; private set; }

        public User User { get; private set; }

        #endregion
    }
}