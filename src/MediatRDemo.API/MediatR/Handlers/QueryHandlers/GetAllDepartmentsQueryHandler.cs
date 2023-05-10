namespace MediatRDemo.API.MediatR.Handlers.QueryHandlers;

using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using global::MediatR;

using MediatRDemo.API.DTOs;
using MediatRDemo.API.MediatR.Handlers;
using MediatRDemo.API.MediatR.Requests.Queries;
using MediatRDemo.Data;

public class GetAllDepartmentsQueryHandler : BaseRequestHandler, IRequestHandler<GetAllDepartmentsQuery, IEnumerable<DepartmentDto>>
{
    public GetAllDepartmentsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    public async Task<IEnumerable<DepartmentDto>> Handle(GetAllDepartmentsQuery request, CancellationToken cancellationToken)
        => mapper.Map<IEnumerable<DepartmentDto>>(await unitOfWork.Departments.GetAllAsync(true));
}
