namespace MediatRDemo.API.Controllers;

using System.Net;

using global::MediatR;

using MediatRDemo.API.DTOs;
using MediatRDemo.API.MediatR.Requests.Commands;
using MediatRDemo.API.MediatR.Requests.Queries;
using MediatRDemo.API.Models.Requests;

using Microsoft.AspNetCore.Mvc;

[Route("[controller]")]
[ApiController]
public class DepartmentsController : APIControllerBase
{
    public DepartmentsController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet("{id:int:range(1,255)}", Name = nameof(GetDepartmentById))]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<ActionResult<DepartmentDto>> GetDepartmentById(byte id)
    {
        var dto = await mediator.Send(new GetDepartmentByIdQuery(id));
        return dto == null ? NotFound() : dto;
    }

    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<DepartmentDto>>> Get()
        => (await mediator.Send(new GetAllDepartmentsQuery())).ToArray();


    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    public async Task<ActionResult> Post([FromBody] DepartmentRequestModel requestModel)
    {
        var dto = await mediator.Send(new CreateDepartmentCommand(requestModel));
        return CreatedAtRoute(nameof(GetDepartmentById), new { dto.Id }, dto);
    }

    [HttpPut("{id:int:range(1,255)}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<ActionResult<DepartmentDto>> Put(byte id, [FromBody] DepartmentRequestModel requestModel)
    {
        var dto = await mediator.Send(new UpdateDepartmentCommand(id, requestModel));
        return dto == null ? NotFound() : dto;
    }

    [HttpDelete("{id:int:range(1,255)}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<ActionResult> Delete(byte id)
        => await mediator.Send(new DeleteDepartmentByIdCommand(id)) ? NoContent() : NotFound();
}
