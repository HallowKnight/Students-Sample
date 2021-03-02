using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Students.Domain.AggregatesModel.LessonAggregate;
using Students.Domain.AggregatesModel.RoleAggregate;
using Students.Domain.AggregatesModel.SchoolAggregate;
using Students.Domain.Common;

namespace Students.Domain.AggregatesModel.UserAggregate
{
    public class User : Entity,IHasDomainEvent, IAggregateRoot
    {
        public string UserName { get; set; }


        public int? ClassId { get; set; }
        public List<UserLessons> UserLessons { get; set; }
        public List<UserRoles> UserRoles { get; set; }
        public Class Class { get; set; }


        public UserLessons UserLesson(int userId, int lessonId)
        {
            return new UserLessons()
            {
                UserId = userId,
                LessonId = lessonId
            };
        }

        public UserRoles UserRole(int userId, int roleId)
        {
            return new UserRoles()
            {
                UserId = userId,
                RoleId = roleId
            };
        }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
           
    }
}