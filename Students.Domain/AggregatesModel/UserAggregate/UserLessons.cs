using Students.Domain.AggregatesModel.LessonAggregate;
using Students.Domain.Common;

namespace Students.Domain.AggregatesModel.UserAggregate
{
    public class UserLessons : Entity
    {
        #region Constructor

        public UserLessons(int userId, int lessonId, int id = 0) : base(id)
        {
            _userId = userId;
            _lessonId = lessonId;
        }

        #endregion

        public int UserId => _userId;
        private int _userId;

        public int LessonId => _lessonId;
        private int _lessonId;

        #region Relations

        public Lesson Lesson { get; private set; }

        public User User { get; private set; }

        #endregion
    }
}