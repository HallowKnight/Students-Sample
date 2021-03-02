using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Students.Application.Users.Queries.GetAllUsers;
using Students.Presentation.Controllers;

namespace Students.Presentation.Hubs
{
    public class UsersListHub : Hub
    {
        public async Task UsersListChanged()
        {
            
        }

        
    }
}