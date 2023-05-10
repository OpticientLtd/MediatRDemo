namespace MediatRDemo.API.MediatR.Handlers.QueryHandlers;

using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using global::MediatR;

using MediatRDemo.API.DTOs;
using MediatRDemo.API.MediatR.Handlers;
using MediatRDemo.API.MediatR.Requests.Queries;
using MediatRDemo.Data;
using MediatRDemo.Data.Models;

public class GetEmployeeByIdQueryHandler : BaseRequestHandler, IRequestHandler<GetEmployeeByIdQuery, EmployeeDto>
{
    public GetEmployeeByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {

    }
    public async Task<EmployeeDto> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        => mapper.Map<Employee, EmployeeDto>(await unitOfWork.Employees.GetAsync(true, request.Id));
}
