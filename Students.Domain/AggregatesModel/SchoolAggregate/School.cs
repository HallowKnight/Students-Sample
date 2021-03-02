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

        public string SchoolTitle { get; set; }

        public List<Class> Classes { get; set; }


        public School NewSchool(string schoolTitle)
        {
            return new School()
            {
                SchoolTitle = schoolTitle
            };
        }
        
        public Class NewClass(string classTitle,int schoolId)
        {
             return new Class()
            {
                SchoolId = schoolId,
                ClassTitle = classTitle
            };
        }

        public Class GetClass(int classId)
        {
            return Classes.First(c => c.Id == classId);
        }
    }
}