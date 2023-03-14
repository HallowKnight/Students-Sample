using System;
using System.Collections.Generic;
using Students.Domain.AggregatesModel.SchoolAggregate;
using Students.Domain.Common;

namespace Students.Domain.AggregatesModel.UserAggregate;

public class User : Entity, IHasDomainEvent, IAggregateRoot
{
    #region Contrustor

    public User(string userName, int? classId)
    {
        UserName = !string.IsNullOrEmpty(userName) ? userName : throw new ArgumentNullException(userName);

        if (classId != null)
            ClassId = classId;
    }

    #endregion

    public string UserName { get; private set; }

    public int? ClassId { get; }

    #region Relations

    public List<UserLessons> UserLessons { get; private set; }
    public List<UserRoles> UserRoles { get; private set; }
    public Class Class { get; private set; }

    public List<DomainEvent> DomainEvents { get; set; } = new();

    #endregion

    #region Validations And Helpers

    public UserLessons UserLesson(int userId, int lessonId)
    {
        return new UserLessons(userId, userId);
    }

    public UserRoles UserRole(int userId, int roleId)
    {
        return new UserRoles(userId, roleId);
    }

    public User UpdateUser(User user, string newUserName)
    {
        user.UserName = newUserName;
        return user;
    }

    #endregion
}