using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Arena.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class VersionController : ControllerBase
	{
		private readonly ILogger<VersionController> _logger;

		public VersionController(ILogger<VersionController> logger)
		{
			_logger = logger;
		}

		[HttpGet]
		[Route("")]
		public Task<JsonResult> Get()
		{
			_logger.LogInformation("Getting version");

			return Task.FromResult(new JsonResult(new { version = "v1" }));
		}
	}
}