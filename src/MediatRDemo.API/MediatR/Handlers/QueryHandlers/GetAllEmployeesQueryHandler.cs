namespace MediatRDemo.API.MediatR.Handlers.QueryHandlers;

using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using global::MediatR;

using MediatRDemo.API.DTOs;
using MediatRDemo.API.MediatR.Handlers;
using MediatRDemo.API.MediatR.Requests.Queries;
using MediatRDemo.Data;

public class GetAllEmployeesQueryHandler : BaseRequestHandler, IRequestHandler<GetAllEmployeesQuery, IEnumerable<EmployeeDto>>
{
    public GetAllEmployeesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    public async Task<IEnumerable<EmployeeDto>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        => mapper.Map<IEnumerable<EmployeeDto>>(await unitOfWork.Employees.GetAllAsync(true));
}
