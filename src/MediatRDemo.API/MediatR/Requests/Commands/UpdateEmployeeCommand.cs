namespace MediatRDemo.API.MediatR.Requests.Commands;

using global::MediatR;

using MediatRDemo.API.DTOs;
using MediatRDemo.API.Models.Requests;

public record UpdateEmployeeCommand(int Id, EmployeeRequestModel RequestModel) : IRequest<EmployeeDto>;
