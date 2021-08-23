using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspProjekat.Application;
using AspProjekat.Application.Commands;
using AspProjekat.Application.DataTransfer;
using AspProjekat.Application.Queries;
using AspProjekat.Application.Searches;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspProjekat.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IApplicationActor actor;
		private readonly UseCaseExecutor executor;

		public UserController(IApplicationActor actor, UseCaseExecutor executor)
		{
			this.actor = actor;
			this.executor = executor;
		}
		// GET: api/<UserController>
		[HttpGet]
		public IActionResult Get([FromQuery] UserSearch search, [FromServices] IGetUsersQuery query)
		{
			return Ok(executor.ExecuteQuery(query, search));
		}

		// GET api/<UserController>/5
		[HttpGet("{id}")]
		public IActionResult Get(int id, [FromServices] IGetOneUserQuery command)
		{
			return Ok(executor.ExecuteQuery(command, id));
		}


		// PUT api/<UserController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] UserUpdateDto dto, [FromServices] IUpdateUserCommand command)
		{
			executor.ExecuteCommandUpdate(command, dto, id);
		}

		// DELETE api/<UserController>/5
		[HttpDelete("{id}")]
		public IActionResult Delete(int id, [FromServices] IDeleteUserCommand command)
		{
			executor.ExecuteCommand(command, id);
			return NoContent();
		}
	}
}
