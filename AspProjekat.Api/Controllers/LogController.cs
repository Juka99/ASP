using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspProjekat.Application;
using AspProjekat.Application.Queries;
using AspProjekat.Application.Searches;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspProjekat.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LogController : ControllerBase
	{
		private readonly IApplicationActor actor;
		private readonly UseCaseExecutor executor;

		public LogController(IApplicationActor actor, UseCaseExecutor executor)
		{
			this.actor = actor;
			this.executor = executor;
		}

		// GET: api/<LogController>
		[HttpGet]
		public IActionResult Get([FromQuery] LogSearch search, [FromServices] IGetLogsQuery query)
		{
			return Ok(executor.ExecuteQuery(query, search));
		}
	}
}
