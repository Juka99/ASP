using System;
using System.Collections.Generic;
using System.Text;

namespace AspProjekat.Domain
{
	public class Category : Entity
	{
		public string Name { get; set; }

		public virtual ICollection<BlogCategory> CategoriesBlog { get; set; } = new HashSet<BlogCategory>();
	}
}
