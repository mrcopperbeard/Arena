using System;
using System.Threading.Tasks;

using Arena.Core;
using Arena.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Arena.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
	    private readonly IGameDataProvider _dataProvider;

	    public GameController(IGameDataProvider dataProvider)
	    {
		    _dataProvider = dataProvider;
	    }

		[HttpPost]
	    public async Task<JsonResult> MakeTurn([FromBody]Turn turn)
	    {
		    var turnResult = await _dataProvider.MakeTurn(turn);

			return new JsonResult(turnResult);
	    }

		[HttpGet]
		[Route("sessionUid:guid")]
	    public async Task<JsonResult> GetDesk(Guid sessionUid)
	    {
		    var desk = await _dataProvider.GetDesk(sessionUid);

			return new JsonResult(desk);
	    }
    }
}