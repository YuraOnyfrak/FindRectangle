using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindRectangle.Application.Queries.GetCountRectangleQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FindRectangle.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculateRectangleController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public CalculateRectangleController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpPost]
        public async Task<int> Get([FromBody]GetCountRectangleQuery query)
        {
            return await _mediatr.Send(query);
        }
    }
}