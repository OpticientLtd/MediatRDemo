namespace MediatRDemo.API.Controllers;

using System.Net;

using global::MediatR;

using MediatRDemo.API.DTOs;
using MediatRDemo.API.MediatR.Notifications;
using MediatRDemo.API.MediatR.Requests.Commands;
using MediatRDemo.API.MediatR.Requests.Queries;
using MediatRDemo.API.Models.Requests;

using Microsoft.AspNetCore.Mvc;

[Route("[controller]")]
[ApiController]
public class EmployeesController : APIControllerBase
{
    public EmployeesController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet("{id:int}", Name = nameof(GetEmployeeById))]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<ActionResult<EmployeeDto>> GetEmployeeById(int id)
    {
        var dto = await mediator.Send(new GetEmployeeByIdQuery(id));
        return dto == null ? NotFound() : Ok(dto);
    }

    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<EmployeeDto>>> Get()
        => (await mediator.Send(new GetAllEmployeesQuery())).ToArray();


    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    public async Task<IActionResult> Post([FromBody] EmployeeRequestModel requestModel)
    {
        var dto = await mediator.Send(new CreateEmployeeCommand(requestModel));
        await mediator.Publish(new EmployeeAddedNotification(dto.Id));
        return CreatedAtRoute(nameof(GetEmployeeById), new { dto.Id }, dto);
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<ActionResult<EmployeeDto>> Put(int id, [FromBody] EmployeeRequestModel requestModel)
    {
        var dto = await mediator.Send(new UpdateEmployeeCommand(id, requestModel));
        return dto == null ? NotFound() : dto;
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<ActionResult> Delete(int id)
        => await mediator.Send(new DeleteEmployeeByIdCommand(id)) ? NoContent() : NotFound();

}
