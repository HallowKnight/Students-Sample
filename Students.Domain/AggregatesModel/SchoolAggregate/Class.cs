using System;
using System.Collections.Generic;
using Students.Domain.AggregatesModel.UserAggregate;
using Students.Domain.Common;

namespace Students.Domain.AggregatesModel.SchoolAggregate
{
    public class Class : Entity
    {
        #region Contsructor

        public Class(int schoolId, string classTitle)
        {
            SchoolId = schoolId;
            ClassTitle = !string.IsNullOrEmpty(classTitle) ? classTitle : throw new ArgumentNullException(classTitle);
        }

        #endregion

        public string ClassTitle { get; }

        public int SchoolId { get; }


        #region Relations

        public School School { get; private set; }

        public List<User> Users { get; private set; }

        #endregion
    }
}