using System;
using System.Collections.Generic;
using System.Text;

namespace AspProjekat.Application.DataTransfer
{
	public class BlogGetDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public ICollection<CategoryDto> Categories { get; set; }
		public ICollection<ImageDto> ImageDtos { get; set; }
	}
}
