namespace MediatRDemo.API.MediatR.Requests.Commands;

using global::MediatR;

public record DeleteDepartmentByIdCommand(byte Id) : IRequest<bool>;
