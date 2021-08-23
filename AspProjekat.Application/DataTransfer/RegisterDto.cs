using System;
using System.Collections.Generic;
using System.Text;

namespace AspProjekat.Application.DataTransfer
{
	public class RegisterDto
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public string Email { get; set; }
		public HashSet<int> UseCasesIds => new HashSet<int> {5, 7, 10, 11, 17, 20};
	}
}
