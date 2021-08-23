using System;
using System.Collections.Generic;
using System.Text;

namespace AspProjekat.Application.DataTransfer
{
	public class CommentGetDto
	{
		public int Id { get; set; }
		public string Text { get; set; }
		public int UserId { get; set; }
		public string Username { get; set; }
		public int BlogId { get; set; }
		public string Name { get; set; }
	}
}
