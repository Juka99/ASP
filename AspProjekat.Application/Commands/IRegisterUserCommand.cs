using AspProjekat.Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspProjekat.Application.Commands
{
	public interface IRegisterUserCommand : ICommand<RegisterDto>
	{
	}
}
