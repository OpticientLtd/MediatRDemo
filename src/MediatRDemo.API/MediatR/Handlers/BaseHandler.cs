namespace MediatRDemo.API.MediatR.Handlers;

using MediatRDemo.Data;


public abstract class BaseHandler
{
    protected readonly IUnitOfWork unitOfWork;


    public BaseHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
}