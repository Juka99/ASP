using System;
using System.Collections.Generic;
using System.Text;

namespace AspProjekat.Application.Exceptions
{
	public class DeleteYourselfException : Exception
	{
		public DeleteYourselfException(int id, Type type) : base("You can not delete yourself!")
		{
		}
	}
}
