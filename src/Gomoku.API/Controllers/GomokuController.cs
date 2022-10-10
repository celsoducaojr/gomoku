using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;
using MediatR;
using System.Threading.Tasks;
using Gomoku.Pipeline.Handlers.Create;
using Gomoku.Pipeline.Handlers.PlaceStone;
using Gomoku.Domain;

namespace Gomoku.Controllers
{

    [ApiController]
    [Produces("application/json")]
    [Route("[controller]/board")]
    public class GomokuController : ControllerBase  
    {
        IMediator _mediator;

        public GomokuController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        public IActionResult Create()
        {
            _mediator.Send(new CreateBoardRequest());
            return Ok();
        }

        [HttpPut("play/stone/place")]
        public IActionResult Place([FromBody] Point point)
        {
            var result = _mediator.Send(new PlaceStoneRequest()
            {
                Point = point
            });

            return Ok(result.Result.PlacementResult);
        }
    }
}
