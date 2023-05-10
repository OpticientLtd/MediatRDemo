namespace MediatRDemo.API.MediatR.Requests.Queries;

using global::MediatR;

using MediatRDemo.API.DTOs;

public record GetAllEmployeesQuery : IRequest<IEnumerable<EmployeeDto>>
{
}
