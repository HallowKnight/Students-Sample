using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Students.Domain.AggregatesModel.UserAggregate;
using Students.Domain.Common;

namespace Students.Domain.AggregatesModel.LessonAggregate
{
    public class Lesson : Entity,IAggregateRoot
    {

        public string LessonTitle { get; set; }

        public List<UserLessons> UserLessons { get; set; }

        
        
        public Lesson NewLesson(string lessonTitle)
        {
            return new Lesson()
            {
                LessonTitle = lessonTitle
            };
        }
        
        
        
    }
}