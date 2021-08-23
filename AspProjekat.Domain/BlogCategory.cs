using System;
using System.Collections.Generic;
using System.Text;

namespace AspProjekat.Domain
{
	public class BlogCategory
	{
		public int BlogId { get; set; }
		public int CategoryId { get; set; }

		public virtual Blog Blog { get; set; }
		public virtual Category Category { get; set; }
	}
}
