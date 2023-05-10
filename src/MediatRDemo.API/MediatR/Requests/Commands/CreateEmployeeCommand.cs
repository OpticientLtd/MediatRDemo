namespace MediatRDemo.API.MediatR.Requests.Commands;

using global::MediatR;

using MediatRDemo.API.DTOs;
using MediatRDemo.API.Models.Requests;

public record CreateEmployeeCommand(EmployeeRequestModel RequestModel) : IRequest<EmployeeDto>;
