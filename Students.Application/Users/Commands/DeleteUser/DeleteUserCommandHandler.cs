using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Students.Domain.AggregatesModel.UserAggregate;
using Students.Domain.Common;
//using Students.Domain.Events;

namespace Students.Application.Users.Commands.DeleteUser
{
    public class DeleteStudentCommandHandler : IRequestHandler<DeleteUserCommand,int>
    {
        
        private readonly IUserCommands _userCommands;
        private readonly IUserQueries _userQueries;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteStudentCommandHandler(IUserCommands userCommands,IUserQueries userQueries,IUnitOfWork unitOfWork)
        {
            _userCommands = userCommands;
            _userQueries = userQueries;
            _unitOfWork = unitOfWork;
        } 
        
        public async Task<int> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            User user = await _userQueries.GetUserByIdAsync(request.UserId);
            _userCommands.DeleteUser(user);

           // user.DomainEvents.Add(new UsersChangedEvent(user));
            request.transctionCount += 1;
            
            return request.transctionCount;
        }
    }
}