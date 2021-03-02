using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Students.Domain.AggregatesModel.UserAggregate;
using Students.Domain.Common;

namespace Students.Domain.AggregatesModel.SchoolAggregate
{
    public class Class : Entity
    {

        public string ClassTitle { get; set; }

        public int SchoolId { get; set; }
            
        
        public School School { get; set; }
        
        public List<User> Users { get; set; }

    }
}