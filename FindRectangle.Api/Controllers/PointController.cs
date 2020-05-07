using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindRectangle.Application.Commands;
using FindRectangle.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FindRectangle.Api.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class PointController : Controller
  {
    private readonly IMediator _mediator;

    public PointController(IMediator mediator)
    {
      _mediator = mediator;
    }


    /// <summary>
    ///Create point
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<int>> Create(CreatePointCommand command)
    {
      await _mediator.Send(command, HttpContext.RequestAborted);
      return Ok();
    }


    /// <summary>
    ///Get points by group
    /// </summary>
    /// <param name="groupId">group Id</param>
    /// <returns></returns>
    [HttpGet("{groupId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<int[,]> Get(int groupId)
    {
      return await _mediator.Send(new GetPointsByGroupQuery() { GroupId = groupId }, HttpContext.RequestAborted);
    }
  }
}
