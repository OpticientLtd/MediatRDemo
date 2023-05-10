namespace MediatRDemo.API.MediatR.Handlers.CommandHandlers;

using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using global::MediatR;

using MediatRDemo.API.MediatR.Handlers;
using MediatRDemo.API.MediatR.Requests.Commands;
using MediatRDemo.Data;

public class DeleteDepartmentByIdCommandHandler : BaseRequestHandler, IRequestHandler<DeleteDepartmentByIdCommand, bool>
{
    public DeleteDepartmentByIdCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    public async Task<bool> Handle(DeleteDepartmentByIdCommand request, CancellationToken cancellationToken)
    {
        var department = await unitOfWork.Departments.GetAsync(false, request.Id);
        if (department == null)
        {
            return false;
        }

        unitOfWork.Departments.Remove(department);
        return await unitOfWork.CompleteAsync();
    }
}
