using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Students.Domain.AggregatesModel.LessonAggregate;
using Students.Domain.AggregatesModel.RoleAggregate;
using Students.Domain.AggregatesModel.SchoolAggregate;
using Students.Domain.Common;

namespace Students.Domain.AggregatesModel.UserAggregate
{
    public class User : Entity, IHasDomainEvent, IAggregateRoot
    {
        public User(int id, string userName, int? classId) : base(id)
        {
            base._Id = id;
            if (userName != null)
                UserName = userName;
            if (classId != null)
                _classId = classId;
        }

        public string UserName { get; private set; }

        public int? ClassId => _classId;
        private int? _classId;

        #region Relations

        public List<UserLessons> UserLessons { get; private set; }
        public List<UserRoles> UserRoles { get; private set; }
        public Class Class { get; private set; }
        
        public List<DomainEvent> DomainEvents { get;  set; } = new List<DomainEvent>();

        #endregion

        #region Validations And Helpers

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
        
        #endregion
    }
}