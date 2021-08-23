using System;
using System.Collections.Generic;
using System.Text;

namespace AspProjekat.Application.Exceptions
{
	public class AlreadyDeletedException : Exception
	{
		public AlreadyDeletedException(int id, Type type) : base($"Entity of type {type.Name} with an id of {id} was already deleted.")
		{

		}
	}
}
