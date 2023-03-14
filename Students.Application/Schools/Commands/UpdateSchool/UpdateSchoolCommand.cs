using MediatR;
using Students.Application.Common.CommitTag;

namespace Students.Application.Schools.Commands.UpdateSchool;

public class UpdateSchoolCommand : IRequest<int>, ICommitable
{
    public int SchoolId { get; set; }
    public string SchoolTitle { get; set; }
    public int TransactionCount { get; set; }
}