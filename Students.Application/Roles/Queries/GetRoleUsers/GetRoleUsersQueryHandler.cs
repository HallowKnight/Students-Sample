using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Students.Domain.AggregatesModel.RoleAggregate;
using Students.Domain.AggregatesModel.UserAggregate;

namespace Students.Application.Roles.Queries.GetRoleUsers
{
    public class GetRoleUsersQueryHandler : IRequestHandler<GetRoleUsersQuery, List<GetRoleUsersDto>>
    {
        private readonly IRoleQueries _roleQueries;

        public GetRoleUsersQueryHandler(IRoleQueries roleQueries)
        {
            _roleQueries = roleQueries;
        }

        public async Task<List<GetRoleUsersDto>> Handle(GetRoleUsersQuery request, CancellationToken cancellationToken)
        {
            List<User> roleUsers = await _roleQueries.GetRoleUsersAsync(request.RoleId);

            List<GetRoleUsersDto> roleUsersDto = new List<GetRoleUsersDto>();

            foreach (User user in roleUsers)
                roleUsersDto.Add(new GetRoleUsersDto
                {
                    UserId = user.Id,
                    UserName = user.UserName
                });

            return roleUsersDto;
        }
    }
}