using System;
using System.Collections.Generic;
using System.Text;

namespace AspProjekat.Domain
{
	public class Blog : Entity
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public int UserId { get; set; }
		public virtual User User { get; set; }

		public virtual ICollection<BlogCategory> BlogCategories { get; set; } = new HashSet<BlogCategory>();
	}
}
