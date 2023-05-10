namespace MediatRDemo.API.MediatR.Handlers;

using AutoMapper;

using MediatRDemo.Data;

public abstract class BaseRequestHandler : BaseHandler
{
    protected readonly IMapper mapper;
    public BaseRequestHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork)
    {
        this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
}
