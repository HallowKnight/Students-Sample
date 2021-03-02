using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Students.Domain.AggregatesModel.UserAggregate;

namespace Students.Application.Users.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery,List<GetAllUsersDto>>
    {
        
        private readonly IUserQueries _userQueries;

        public GetAllUsersQueryHandler(IUserQueries userQueries)
        {
            _userQueries = userQueries;
        }
        
        public async Task<List<GetAllUsersDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            List<User> users = await _userQueries.GetAllUsersAsync();
            List<GetAllUsersDto> studentsList = new List<GetAllUsersDto>();

            foreach (User user in users)
            {
                studentsList.Add(new GetAllUsersDto()
                {
                    UserId = user.Id,
                    UserName = user.UserName
                });
            }
            
            
            
            return studentsList;
        }
    }
}