using System;
using System.Threading.Tasks;

using Arena.Core;
using Microsoft.AspNetCore.Mvc;

namespace Arena.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SessionController : ControllerBase
	{
		private readonly ISessionDataProvider _sessionDataProvider;

		public SessionController(ISessionDataProvider sessionDataProvider)
		{
			_sessionDataProvider = sessionDataProvider;
		}

		[HttpPost]
		[Route("new")]
		public async Task<JsonResult> New()
		{
			var sessionInfo = await _sessionDataProvider.New();

			return new JsonResult(sessionInfo);
		}

		[HttpGet]
		[Route("{sessionUid:guid}")]
		public async Task<JsonResult> Get(Guid sessionUid)
		{
			var sessionInfo = await _sessionDataProvider.Get(sessionUid);

			return new JsonResult(sessionInfo);
		}
	}
}