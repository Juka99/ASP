using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspProjekat.Application;
using AspProjekat.Application.Commands;
using AspProjekat.Application.DataTransfer;
using AspProjekat.Application.Exceptions;
using AspProjekat.Application.Queries;
using AspProjekat.Application.Searches;
using AspProjekat.DataAccess;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspProjekat.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BlogController : ControllerBase
	{
		private readonly IApplicationActor actor;
		private readonly UseCaseExecutor executor;

		public BlogController(IApplicationActor actor, UseCaseExecutor executor)
		{
			this.actor = actor;
			this.executor = executor;
		}

		// GET: api/<BlogController>
		[HttpGet]
		public IActionResult Get([FromQuery] Search search, [FromServices] IGetBlogsQuery query)
		{
			return Ok(executor.ExecuteQuery(query, search));
		}

		// GET api/<BlogController>/5
		[HttpGet("{id}")]
		public IActionResult Get(int id, [FromServices] IGetOneBlogQuery command)
		{
			return Ok(executor.ExecuteQuery(command, id));
		}

		// POST api/<BlogController>
		[HttpPost]
		public void Post([FromBody] BlogDto dto, [FromServices] ICreateBlogCommand command)
		{
			executor.ExecuteCommand(command, dto);
		}

		// PUT api/<BlogController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] BlogDto dto, [FromServices] IUpdateBlogCommand command)
		{
			executor.ExecuteCommandUpdate(command, dto, id);
		}

		// DELETE api/<BlogController>/5
		[HttpDelete("{id}")]
		public IActionResult Delete(int id, [FromServices] IDeleteBlogCommand command)
		{
			executor.ExecuteCommand(command, id);
			return NoContent();
		}
	}
}
