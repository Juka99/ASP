using AspProjekat.Application;
using AspProjekat.DataAccess;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspProjekat.Implementation.Logging
{
	public class DatabaseUseCaseLogger : IUseCaseLogger
	{
		private readonly AspProjekatContext _context;

		public DatabaseUseCaseLogger(AspProjekatContext context)
		{
			_context = context;
		}

		public void Log(IUseCase useCase, IApplicationActor actor, object useCaseData)
		{
			_context.UseCaseLogs.Add(new Domain.UseCaseLog
			{
				Actor = actor.Identity,
				Data = JsonConvert.SerializeObject(useCaseData),
				Date = DateTime.UtcNow,
				UseCaseName = useCase.Name
			});

			_context.SaveChanges();
		}
	}
}
