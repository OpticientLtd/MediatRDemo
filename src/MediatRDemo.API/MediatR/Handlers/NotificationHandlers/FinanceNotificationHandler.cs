namespace MediatRDemo.API.MediatR.Handlers.NotificationHandlers;

using System.Threading;
using System.Threading.Tasks;

using global::MediatR;

using MediatRDemo.API.MediatR.Handlers;
using MediatRDemo.API.MediatR.Notifications;
using MediatRDemo.Data;

public class FinanceNotificationHandler : BaseNotificationHandler, INotificationHandler<EmployeeAddedNotification>
{
    public FinanceNotificationHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public async Task Handle(EmployeeAddedNotification notification, CancellationToken cancellationToken)
    {
        var employee = await unitOfWork.Employees.GetAsync(true, notification.EmployeeId);
        Console.WriteLine($"Finance Department is informed for newly created Employee = {employee.Id}, Name={employee.Name}");
    }
}
