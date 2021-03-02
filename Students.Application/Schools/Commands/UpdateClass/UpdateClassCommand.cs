using MediatR;
using Students.Application.Common.CommitTag;

namespace Students.Application.Schools.Commands.UpdateClass
{
    public class UpdateClassCommand : IRequest<int>,ICommitable
    {
        public int transctionCount { get; set; }

        public int ClassId { get; set; }
        public int SchoolId { get; set; }
        public string ClassTitle { get; set; }
    }
}