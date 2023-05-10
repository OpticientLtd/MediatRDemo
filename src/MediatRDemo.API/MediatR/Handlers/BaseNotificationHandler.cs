namespace MediatRDemo.API.MediatR.Handlers;

using MediatRDemo.Data;

public abstract class BaseNotificationHandler : BaseHandler
{
    protected BaseNotificationHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }
}
