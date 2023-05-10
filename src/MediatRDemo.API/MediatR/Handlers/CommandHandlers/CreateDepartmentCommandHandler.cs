namespace MediatRDemo.API.MediatR.Handlers.CommandHandlers;

using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using global::MediatR;

using MediatRDemo.API.DTOs;
using MediatRDemo.API.MediatR.Handlers;
using MediatRDemo.API.MediatR.Requests.Commands;
using MediatRDemo.Data;
using MediatRDemo.Data.Models;

public class CreateDepartmentCommandHandler : BaseRequestHandler, IRequestHandler<CreateDepartmentCommand, DepartmentDto>
{
    public CreateDepartmentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    public async Task<DepartmentDto> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
    {
        var department = mapper.Map<Department>(request.RequestModel);
        await unitOfWork.Departments.AddAsync(department);
        await unitOfWork.CompleteAsync();
        return mapper.Map<DepartmentDto>(department);
    }
}
