using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Students.Domain.AggregatesModel.UserAggregate;
using Students.Domain.Events;
using Students.Domain.Events.UsersChanged;
using Students.Infrastructure.Persistence.DBContext;

namespace Students.Application.Users.Commands.DeleteUser
{
    public class DeleteStudentCommandHandler : IRequestHandler<DeleteUserCommand,int>
    {
        
        private readonly IUserCommands _userCommands;
        private readonly IUserQueries _userQueries;
        private readonly IMediator _mediator;
        private readonly StudentsDbContext _context;

        public DeleteStudentCommandHandler(IUserCommands userCommands, IUserQueries userQueries, IMediator mediator, StudentsDbContext context)
        {
            _userCommands = userCommands;
            _userQueries = userQueries;
            _mediator = mediator;
            _context = context;
        }
        
        public async Task<int> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            User user = await _userQueries.GetUserByIdAsync(request.UserId);
            _userCommands.DeleteUser(user);

            _context.SaveChanges();
            
            await _mediator.Publish(new UsersChangedEvent());

            request.transctionCount += 1;
            
            return request.transctionCount;
        }
    }
}