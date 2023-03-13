using MediatR;
using Students.Application.Common.CommitTag;

namespace Students.Application.Schools.Commands.DeleteClass
{
    public class DeteleClassCommand : IRequest<int>, ICommitable
    {
        public int ClassId { get; set; }
        public int TransactionCount { get; set; }
    }
}