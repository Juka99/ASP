using AspProjekat.Application.DataTransfer;
using AspProjekat.Application.Exceptions;
using AspProjekat.Application.Queries;
using AspProjekat.DataAccess;
using AspProjekat.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AspProjekat.Implementation.Queries
{
	public class EfGetCommentQuery : IGetCommentQuery
	{
		private readonly AspProjekatContext _context;

		public EfGetCommentQuery(AspProjekatContext context)
		{
			_context = context;
		}

		public int Id => 20;

		public string Name => "Display coments by blog.";

		public CommentGetDto Execute(int id)
		{
			var comment = _context.Comments.Find(id);

			if (comment == null)
			{
				throw new EntityNotFoundException(id, typeof(Comment));
			}

			var blog = _context.Blogs.Find(comment.BlogId);
			var blogDto = new BlogGetDto
			{
				Id = blog.Id,
				Name = blog.Name
			};

			var user = _context.Users.Find(comment.UserId);
			var userDto = new UserGetDto
			{
				Id = user.Id,
				Username = user.UserName
			};

			var result = new CommentGetDto
			{
				Id = comment.Id,
				Text = comment.Text,
				UserId = userDto.Id,
				Username = userDto.Username,
				BlogId = blogDto.Id,
				Name = blogDto.Name
			};

			return result;
		}
	}
}
