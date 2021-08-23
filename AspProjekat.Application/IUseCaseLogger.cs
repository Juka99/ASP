using System;
using System.Collections.Generic;
using System.Text;

namespace AspProjekat.Application
{
	public interface IUseCaseLogger
	{
		void Log(IUseCase useCase, IApplicationActor actor, object useCaseData);
	}
}
