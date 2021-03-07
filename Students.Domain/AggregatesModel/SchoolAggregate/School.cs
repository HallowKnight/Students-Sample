using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.NetworkInformation;
using Students.Domain.Common;

namespace Students.Domain.AggregatesModel.SchoolAggregate
{
    public class School : Entity,IAggregateRoot
    {

        #region Constructors

        public School( string schoolTitle,int id = 0) : base(id)
        {
            SchoolTitle = !String.IsNullOrEmpty(schoolTitle)?schoolTitle: throw new ArgumentNullException(schoolTitle);
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
        
        public Class NewClass(string classTitle,int schoolId)
        {
            return new Class(schoolId,classTitle);
        }

        public Class GetClass(int classId)
        {
            return Classes.First(c => c._Id == classId);
        }

        public School UpdateSchoolTitle(School school, string newSchoolTitle)
        {
            school.SchoolTitle = newSchoolTitle;
            return school;
        }
        
        #endregion
        
    
    }
}