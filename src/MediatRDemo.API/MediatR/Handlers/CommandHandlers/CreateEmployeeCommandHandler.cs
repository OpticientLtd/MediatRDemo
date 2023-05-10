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

public class CreateEmployeeCommandHandler : BaseRequestHandler, IRequestHandler<CreateEmployeeCommand, EmployeeDto>
{
    public CreateEmployeeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    public async Task<EmployeeDto> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = mapper.Map<Employee>(request.RequestModel);
        await unitOfWork.Employees.AddAsync(employee);
        await unitOfWork.CompleteAsync();
        return mapper.Map<EmployeeDto>(employee);
    }
}
