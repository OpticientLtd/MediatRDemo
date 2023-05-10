namespace MediatRDemo.API.MediatR.Requests.Queries;

using global::MediatR;

using MediatRDemo.API.DTOs;

public record GetEmployeeByIdQuery(int Id) : IRequest<EmployeeDto>;

