using System.Threading;
using System.Threading.Tasks;
using MassTransit;
using MediatR;
using Students.Domain.AggregatesModel.UserAggregate;
using Students.Domain.Contracts;
using Students.Infrastructure.Persistence.DBContext;

namespace Students.Application.Users.Commands.CreateUser;

public class CreateStudentCommandHandler : IRequestHandler<CreateUserCommand, int>
{
    private readonly StudentsDbContext _context;
    private readonly IPublishEndpoint _publishEndpoint;

    private readonly IUserCommands _userCommands;

    public CreateStudentCommandHandler(IUserCommands userCommands, StudentsDbContext context,
        IPublishEndpoint publishEndpoint)
    {
        _userCommands = userCommands;
        _context = context;
        _publishEndpoint = publishEndpoint;
    }

    public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        await _userCommands.AddUserAsync(request.UserName);
        await _context.SaveChangesAsync();
        await _publishEndpoint.Publish<UsersChanged>(request);

        request.TransactionCount += 1;

        return request.TransactionCount;
    }
}