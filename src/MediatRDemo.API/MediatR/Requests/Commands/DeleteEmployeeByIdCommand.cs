namespace MediatRDemo.API.MediatR.Requests.Commands;

using global::MediatR;

public record DeleteEmployeeByIdCommand(int Id) : IRequest<bool>;
