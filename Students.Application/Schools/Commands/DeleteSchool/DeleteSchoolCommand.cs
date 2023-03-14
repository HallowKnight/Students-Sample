using MediatR;
using Students.Application.Common.CommitTag;

namespace Students.Application.Schools.Commands.DeleteSchool;

public class DeleteSchoolCommand : IRequest<int>, ICommitable
{
    public int SchoolId { get; set; }
    public int TransactionCount { get; set; }
}