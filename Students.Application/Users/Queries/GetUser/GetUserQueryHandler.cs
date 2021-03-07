using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Students.Domain.AggregatesModel.UserAggregate;

namespace Students.Application.Users.Queries.GetUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, GetUserDto>
    {
        private readonly IUserQueries _userQueries;

        public GetUserQueryHandler(IUserQueries userQueries)
        {
            _userQueries = userQueries;
        }


        public async Task<GetUserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {

            User user = await _userQueries.GetUserByIdAsync(request.UserId);

            return new GetUserDto()
            {
                UserId = user._Id,
                UserName = user.UserName
            };
        }
    }
}