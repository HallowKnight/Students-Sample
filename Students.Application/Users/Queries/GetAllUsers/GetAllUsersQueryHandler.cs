using System.Collections.Generic;
using System.Linq;
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
            return (await _userQueries.GetAllUsersAsync()).Select(user => new GetAllUsersDto
            {
                UserId = user.Id,
                UserName = user.UserName
            }).ToList();
        }
    }
}