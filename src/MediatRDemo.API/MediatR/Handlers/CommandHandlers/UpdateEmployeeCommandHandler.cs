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

public class UpdateEmployeeCommandHandler : BaseRequestHandler, IRequestHandler<UpdateEmployeeCommand, EmployeeDto>
{
    public UpdateEmployeeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    public async Task<EmployeeDto> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = await unitOfWork.Employees.GetAsync(false, request.Id);
        if (employee == null)
        {
            return null;
        }

        mapper.Map(request.RequestModel, employee);
        await unitOfWork.CompleteAsync();
        return mapper.Map<EmployeeDto>(employee);
    }
}
