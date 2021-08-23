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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspProjekat.Api.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		private readonly IApplicationActor actor;
		private readonly UseCaseExecutor executor;

		public CategoryController(IApplicationActor actor, UseCaseExecutor executor)
		{
			this.actor = actor;
			this.executor = executor;
		}

		// GET: api/<RWApiController>
		[HttpGet]
		public IActionResult Get([FromQuery] Search search, [FromServices] IGetCategoriesQuery query)
		{
			return Ok(executor.ExecuteQuery(query, search));
		}

		// GET api/<RWApiController>/5
		[HttpGet("{id}")]
		public IActionResult Get(int id, [FromServices] IGetOneCategoriesQuery comnand)
		{
			return Ok(executor.ExecuteQuery(comnand, id));
		}

		// POST api/<RWApiController>
		[HttpPost]
		public void Post([FromBody] CategoryDto dto, [FromServices] ICreateCategoryCommand command)
		{
			executor.ExecuteCommand(command, dto);
		}

		// PUT api/<RWApiController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] CategoryDto dto, [FromServices] IUpdateCategoryCommand command)
		{
			executor.ExecuteCommandUpdate(command, dto, id);
		}

		// DELETE api/<RWApiController>/5
		[HttpDelete("{id}")]
		public IActionResult Delete(int id, [FromServices] IDeleteCategoryCommand command)
		{
			executor.ExecuteCommand(command, id);
			return NoContent();
		}
	}
}
