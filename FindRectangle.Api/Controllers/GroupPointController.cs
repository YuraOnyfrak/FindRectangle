using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindRectangle.Application.Commands;
using FindRectangle.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FindRectangle.Api.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class GroupPointController : ControllerBase
  {
    private readonly IMediator _mediator;

    public GroupPointController(IMediator mediator)
    {
      _mediator = mediator;
    }


    /// <summary>
    /// Create group for points
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<int>> Create(CreatePointGroupCommand command)
    {
      return await _mediator.Send(command, HttpContext.RequestAborted);
    }

    /// <summary>
    /// Get groups
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IEnumerable<GroupPointVM>> Get()
    {
      return await _mediator.Send(new GetGroupPointsQuery(), HttpContext.RequestAborted);
    }
  }
}
