using System.Threading;
using System.Threading.Tasks;
using MassTransit;
using MediatR;
using Students.Domain.AggregatesModel.UserAggregate;
using Students.Domain.Contracts;
using Students.Infrastructure.Persistence.DBContext;

namespace Students.Application.Users.Commands.DeleteUser
{
    public class DeleteStudentCommandHandler : IRequestHandler<DeleteUserCommand, int>
    {
        private readonly StudentsDbContext _context;
        private readonly IPublishEndpoint _publishEndpoint;

        private readonly IUserCommands _userCommands;

        public DeleteStudentCommandHandler(IUserCommands userCommands, StudentsDbContext context,
            IPublishEndpoint publishEndpoint)
        {
            _userCommands = userCommands;
            _context = context;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<int> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            await _userCommands.DeleteUserAsync(request.UserId);

            await _context.SaveChangesAsync();
            await _publishEndpoint.Publish<UsersChanged>(request);

            request.TransactionCount += 1;

            return request.TransactionCount;
        }
    }
}