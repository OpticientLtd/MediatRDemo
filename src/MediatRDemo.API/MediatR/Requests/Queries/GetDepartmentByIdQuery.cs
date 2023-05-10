namespace MediatRDemo.API.MediatR.Requests.Queries;

using global::MediatR;

using MediatRDemo.API.DTOs;

public record GetDepartmentByIdQuery(byte Id) : IRequest<DepartmentDto>;
