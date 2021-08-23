using System;
using System.Collections.Generic;
using System.Text;

namespace AspProjekat.Application.DataTransfer
{
	public class BlogDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public List<int> CategoryIds { get; set; }
		public List<string> Images { get; set; }
	}
}
