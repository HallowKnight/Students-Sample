using MediatR;
using Students.Application.Common.CommitTag;

namespace Students.Application.Schools.Commands.CreateClass
{
    public class CreateClassCommand : IRequest<int>, ICommitable
    {
        public string ClassTitle { get; set; }

        public int SchoolId { get; set; }

        public int TransactionCount { get; set; }
    }
}