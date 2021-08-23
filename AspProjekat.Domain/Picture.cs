using System;
using System.Collections.Generic;
using System.Text;

namespace AspProjekat.Domain
{
	public class Picture
	{
		public int Id { get; set; }
		public string Src { get; set; }
		public int BlogId { get; set; }
		public virtual Blog Blog { get; set; }
	}
}
