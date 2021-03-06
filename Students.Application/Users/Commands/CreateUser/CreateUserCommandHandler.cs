using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Students.Domain.AggregatesModel.UserAggregate;
using Students.Domain.Events;
using Students.Domain.Events.UsersChanged;
using Students.Infrastructure.Persistence.DBContext;

namespace Students.Application.Users.Commands.CreateUser
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateUserCommand,int>
    {

        private readonly IUserCommands _userCommands;
        private readonly IMediator _mediator;
        private readonly StudentsDbContext _context;

        public CreateStudentCommandHandler(IUserCommands userCommands, IMediator mediator, StudentsDbContext context)
        {
            _userCommands = userCommands;
            _mediator = mediator;
            _context = context;
        }
        
        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {

            await _userCommands.AddUserAsync(request.UserName);
            await _context.SaveChangesAsync();
            await _mediator.Publish(new UsersChangedEvent());
            
            request.transctionCount += 1;
            
            return request.transctionCount;
        }
    }
}