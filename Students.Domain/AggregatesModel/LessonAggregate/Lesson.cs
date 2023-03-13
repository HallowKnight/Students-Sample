using System.Collections.Generic;
using Students.Domain.AggregatesModel.UserAggregate;
using Students.Domain.Common;

namespace Students.Domain.AggregatesModel.LessonAggregate
{
    public class Lesson : Entity, IAggregateRoot
    {
        #region Constructor

        public Lesson(string lessonTitle)
        {
            LessonTitle = lessonTitle;
        }

        #endregion

        public string LessonTitle { get; private set; }

        #region Relation

        public List<UserLessons> UserLessons { get; private set; }

        #endregion

        #region Helpers And Validators

        public Lesson NewLesson(string lessonTitle)
        {
            return new Lesson(lessonTitle);
        }

        public Lesson UpdateLessonTitle(Lesson lesson, string newLessonTitle)
        {
            lesson.LessonTitle = newLessonTitle;
            return lesson;
        }

        #endregion
    }
}