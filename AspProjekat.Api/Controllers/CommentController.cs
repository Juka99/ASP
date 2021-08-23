using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspProjekat.Application;
using AspProjekat.Application.Commands;
using AspProjekat.Application.DataTransfer;
using AspProjekat.Application.Queries;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspProjekat.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CommentController : ControllerBase
	{
		private readonly IApplicationActor actor;
		private readonly UseCaseExecutor executor;

		public CommentController(IApplicationActor actor, UseCaseExecutor executor)
		{
			this.actor = actor;
			this.executor = executor;
		}

		// GET api/<CommentController>/5
		[HttpGet("{id}")]
		public IActionResult Get(int id, [FromServices] IGetCommentQuery query)
		{
			return Ok(executor.ExecuteQuery(query, id));
		}

		// POST api/<CommentController>
		[HttpPost("blog/{id}")]
		public void Post(int id, [FromBody] CommentDto dto, [FromServices] ICreateCommentCommand command)
		{
			executor.ExecuteCommandComment(command, dto, id);
		}

		// PUT api/<CommentController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] CommentDto dto, [FromServices] IUpdateCommentCommand command)
		{
			executor.ExecuteCommandUpdate(command, dto, id);
		}

		// DELETE api/<CommentController>/5
		[HttpDelete("{id}")]
		public IActionResult Delete(int id, [FromServices] IDeleteCommentCommand command)
		{
			executor.ExecuteCommand(command, id);
			return NoContent();
		}
	}
}
