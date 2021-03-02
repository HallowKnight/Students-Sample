using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Students.Domain.AggregatesModel.UserAggregate;
using Students.Domain.Common;

namespace Students.Application.Users.Commands.UpdateUser
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateUserCommand,int>
    {
        
        private readonly IUserCommands _userCommands;
        private readonly IUserQueries _userQueries;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateStudentCommandHandler(IUserCommands userCommands,IUserQueries userQueries,IUnitOfWork unitOfWork)
        {
            _userCommands = userCommands;
            _userQueries = userQueries;
            _unitOfWork = unitOfWork;
        } 
        
        public async Task<int> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {

            User user = await _userQueries.GetUserByIdAsync(request.UserId);
            user.UserName = request.UserNewName;
            _userCommands.UpdateUser(user);
            request.transctionCount += 1;
            
            return request.transctionCount;
            
        }
    }
}