using MediatR;
using Students.Application.Common.CommitTag;

namespace Students.Application.Schools.Commands.CreateSchool;

public class CreateSchoolCommand : IRequest<int>, ICommitable
{
    public string SchoolTitle { get; set; }
    public int TransactionCount { get; set; }
}