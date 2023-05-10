namespace MediatRDemo.API.MediatR.Notifications;

using global::MediatR;

public record EmployeeAddedNotification(int EmployeeId) : INotification
{
}
