using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR.Pipeline;
using Students.Application.Common.CommitTag;
using Students.Domain.Common;

namespace Students.Application.Common.Behaviours;

// A custom Pipeline that Is Called Every time that a RequestHandler is Called 
public class CommitPostProcessor<TRequest, TResponse> : IRequestPostProcessor<TRequest, TResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public CommitPostProcessor(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Process(TRequest request, TResponse response, CancellationToken cancellationToken)
    {
        if (request is ICommittable)
            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
    }
}