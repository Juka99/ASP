using System;
using System.Collections.Generic;
using System.Text;

namespace AspProjekat.Application.Exceptions
{
	public class UnauthorizedUseCaseException : Exception
	{
		public UnauthorizedUseCaseException(IUseCase useCase, IApplicationActor actor)
			: base($"Actor with id: {actor.Id} - {actor.Identity} tried to execute {useCase.Name}.")
		{

		}
	}
}
