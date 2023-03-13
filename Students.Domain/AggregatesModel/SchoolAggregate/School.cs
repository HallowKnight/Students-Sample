using System;
using System.Collections.Generic;
using Students.Domain.Common;

namespace Students.Domain.AggregatesModel.SchoolAggregate
{
    public class School : Entity, IAggregateRoot
    {
        #region Constructors

        public School(string schoolTitle)
        {
            SchoolTitle = !string.IsNullOrEmpty(schoolTitle)
                ? schoolTitle
                : throw new ArgumentNullException(schoolTitle);
        }

        #endregion


        public string SchoolTitle { get; private set; }

        #region Relations

        public List<Class> Classes { get; private set; }

        #endregion

        #region Validations and Helpers

        public School NewSchool(string schoolTitle)
        {
            return new School(schoolTitle);
        }

        public Class NewClass(string classTitle, int schoolId)
        {
            return new Class(schoolId, classTitle);
        }


        public School UpdateSchoolTitle(School school, string newSchoolTitle)
        {
            school.SchoolTitle = newSchoolTitle;
            return school;
        }


        public Class UpdateClassTitle(int schoolId, string newClassTitle)
        {
            Class updatingClass = new Class(schoolId, newClassTitle);
            return updatingClass;
        }

        #endregion
    }
}