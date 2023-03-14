using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Students.Domain.AggregatesModel.LessonAggregate;
using Students.Domain.AggregatesModel.UserAggregate;

namespace Students.Application.Lessons.Commands.ComplexTestHandler;

// Used to Handle Specified Command For a Complex action to test "SaveChangesAsync();"
public class ComplexTestHandlerCommandHandler : IRequestHandler<ComplexTestHandlerCommand, int>
{
    private readonly ILessonCommands _lessonCommands;
    private readonly IUserCommands _userCommands;


    public ComplexTestHandlerCommandHandler(ILessonCommands lessonCommands,
        IUserCommands studentCommands)
    {
        _lessonCommands = lessonCommands;
        _userCommands = studentCommands;
    }


    public async Task<int> Handle(ComplexTestHandlerCommand request, CancellationToken cancellationToken)
    {
        await _lessonCommands.AddLessonAsync(request.LessonName);
        request.TransactionCount += 1;
        await _userCommands.AddLessonToUserAsync(request.UserId, request.LessonId);
        request.TransactionCount += 1;
        await _userCommands.AddUserAsync(request.UserName);
        request.TransactionCount += 1;
        await _userCommands.DeleteUserAsync(request.UserId);
        request.TransactionCount += 1;

        return request.TransactionCount;
    }
}