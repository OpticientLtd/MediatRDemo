namespace MediatRDemo.API.MediatR.Handlers.CommandHandlers;

using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using global::MediatR;

using MediatRDemo.API.MediatR.Handlers;
using MediatRDemo.API.MediatR.Requests.Commands;
using MediatRDemo.Data;

public class DeleteEmployeeByIdCommandHandler : BaseRequestHandler, IRequestHandler<DeleteEmployeeByIdCommand, bool>
{
    public DeleteEmployeeByIdCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    public async Task<bool> Handle(DeleteEmployeeByIdCommand request, CancellationToken cancellationToken)
    {
        var employee = await unitOfWork.Employees.GetAsync(false, request.Id);
        if (employee == null)
        {
            return false;
        }

        unitOfWork.Employees.Remove(employee);
        return await unitOfWork.CompleteAsync();
    }
}
