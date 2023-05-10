namespace MediatRDemo.API.MediatR.Handlers.CommandHandlers;

using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using global::MediatR;

using MediatRDemo.API.DTOs;
using MediatRDemo.API.MediatR.Handlers;
using MediatRDemo.API.MediatR.Requests.Commands;
using MediatRDemo.API.Models.Requests;
using MediatRDemo.Data;
using MediatRDemo.Data.Models;

public class UpdateDepartmentCommandHandler : BaseRequestHandler, IRequestHandler<UpdateDepartmentCommand, DepartmentDto>
{
    public UpdateDepartmentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    public async Task<DepartmentDto> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
    {
        var department = await unitOfWork.Departments.GetAsync(false, request.Id);
        if (department == null)
        {
            return null;
        }

        mapper.Map(request.RequestModel, department);
        await unitOfWork.CompleteAsync();
        return mapper.Map<DepartmentDto>(department);
    }
}
