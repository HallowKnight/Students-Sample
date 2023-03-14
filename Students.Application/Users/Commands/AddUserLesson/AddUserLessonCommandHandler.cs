using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Students.Domain.AggregatesModel.UserAggregate;

namespace Students.Application.Users.Commands.AddUserLesson;

public class AddStudentLessonCommandHandler : IRequestHandler<AddUserLessonCommand, int>
{
    private readonly IUserCommands _userCommands;

    public AddStudentLessonCommandHandler(IUserCommands userCommands)
    {
        _userCommands = userCommands;
    }

    public async Task<int> Handle(AddUserLessonCommand request, CancellationToken cancellationToken)
    {
        await _userCommands.AddLessonToUserAsync(request.UserId, request.LessonId);
        request.TransactionCount += 1;
        return request.TransactionCount;
    }
}