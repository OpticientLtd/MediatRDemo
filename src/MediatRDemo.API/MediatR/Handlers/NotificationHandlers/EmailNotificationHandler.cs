namespace MediatRDemo.API.MediatR.Handlers.NotificationHandlers;

using System.Threading;
using System.Threading.Tasks;

using global::MediatR;

using MediatRDemo.API.MediatR.Handlers;
using MediatRDemo.API.MediatR.Notifications;
using MediatRDemo.Data;

public class EmailNotificationHandler : BaseNotificationHandler, INotificationHandler<EmployeeAddedNotification>
{
    public EmailNotificationHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public async Task Handle(EmployeeAddedNotification notification, CancellationToken cancellationToken)
    {
        var employee = await unitOfWork.Employees.GetAsync(true, notification.EmployeeId);
        Console.WriteLine($"Email sent successfully to Employee Id = {employee.Id}, Name = {employee.Name}");
    }
}
