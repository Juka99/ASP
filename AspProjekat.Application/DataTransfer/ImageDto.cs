using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspProjekat.Application.DataTransfer
{
	public class ImageDto
	{
		public string Src { get; set; }
		public IFormFile Image { get; set; }
	}
}
