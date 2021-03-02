using System.Collections.Generic;

namespace Students.Application.Lessons.Queries.GetUserLessons
{
    public class GetUserLessonsDto
    {
        public int UserId { get; set; }
        
        public string UserName { get; set; }

        public List<string> UserLessons { get; set; }
    }
}