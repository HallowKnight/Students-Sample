using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Students.Domain.AggregatesModel.SchoolAggregate;

namespace Students.Application.Schools.Commands.CreateSchool;

public class CreateSchoolCommandhandler : IRequestHandler<CreateSchoolCommand, int>
{
    private readonly ISchoolCommands _schoolCommands;

    public CreateSchoolCommandhandler(ISchoolCommands schoolCommands)
    {
        _schoolCommands = schoolCommands;
    }

    public async Task<int> Handle(CreateSchoolCommand request, CancellationToken cancellationToken)
    {
        await _schoolCommands.CreateSchoolAsync(request.SchoolTitle);
        request.TransactionCount++;

        return request.TransactionCount;
    }
}