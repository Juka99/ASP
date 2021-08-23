using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspProjekat.Application;
using AspProjekat.Application.Commands;
using AspProjekat.Application.DataTransfer;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspProjekat.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RegisterController : ControllerBase
	{
		private readonly UseCaseExecutor _executor;

		public RegisterController(UseCaseExecutor executor)
		{
			_executor = executor;
		}

		// POST api/<RegisterController>
		[HttpPost]
		public void Post([FromBody] RegisterDto dto, [FromServices] IRegisterUserCommand command)
		{
			_executor.ExecuteCommand(command, dto);
		}
	}
}
