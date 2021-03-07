using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Students.Domain.AggregatesModel.UserAggregate;
using Students.Domain.Common;

namespace Students.Domain.AggregatesModel.SchoolAggregate
{
    public class Class : Entity
    {
        #region Contsructor

        public Class(int schoolId, string classTitle, int id = 0) : base(id)
        {
            _schoolId = schoolId;
            ClassTitle = !String.IsNullOrEmpty(classTitle) ? classTitle : throw new ArgumentNullException(classTitle);
        }

        #endregion

        public string ClassTitle { get; private set; }

        public int SchoolId => _schoolId;
        private int _schoolId;


        #region Relations

        public School School { get; private set; }

        public List<User> Users { get; private set; }

        #endregion


        #region Helpers And Validators

        public Class UpdateClassTitle(Class updatingClass, string newClassTitle)
        {
            updatingClass.ClassTitle = newClassTitle;
            return updatingClass;
        }

        #endregion
    }
}