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

public class GetDepartmentByIdQueryHandler : BaseRequestHandler, IRequestHandler<GetDepartmentByIdQuery, DepartmentDto>
{
    public GetDepartmentByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    public async Task<DepartmentDto> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        => mapper.Map<Department, DepartmentDto>(await unitOfWork.Departments.GetAsync(true, request.Id));
}
