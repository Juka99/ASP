using AspProjekat.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspProjekat.Api.Core
{
	public class AnonymusActor : IApplicationActor
	{
		public int Id => 0;

		public string Identity => "Anonymus";

		public IEnumerable<int> AllowedUseCases =>  new List<int> { 12, 5, 11, 10, 20};  
	}
}
