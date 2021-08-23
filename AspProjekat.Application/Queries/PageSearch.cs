using System;
using System.Collections.Generic;
using System.Text;

namespace AspProjekat.Application.Queries
{
	public abstract class PageSearch
	{
		public int PerPage { get; set; } = 10;
		public int Page { get; set; } = 1;
	}
}
