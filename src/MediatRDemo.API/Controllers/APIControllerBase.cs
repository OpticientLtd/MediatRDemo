namespace MediatRDemo.API.Controllers;

using global::MediatR;

using Microsoft.AspNetCore.Mvc;

public class APIControllerBase : ControllerBase
{
    protected readonly IMediator mediator;

    public APIControllerBase(IMediator mediator)
    {
        this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }
}
