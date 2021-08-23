using AspProjekat.Application.Commands;
using AspProjekat.Application.Exceptions;
using AspProjekat.DataAccess;
using AspProjekat.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspProjekat.Implementation.Commands
{
	public class EfDeleteBlogCommand : IDeleteBlogCommand
	{
		private readonly AspProjekatContext _context;

		public EfDeleteBlogCommand(AspProjekatContext context)
		{
			_context = context;
		}
		public int Id => 8;

		public string Name => "Delete blog.";

		public void Execute(int request)
		{
			var blog = _context.Blogs.Find(request);

			if (blog == null)
			{
				throw new EntityNotFoundException(request, typeof(Blog));
			}

			if (blog.IsDeleted == true)
			{
				throw new AlreadyDeletedException(request, typeof(Blog));
			}

			blog.DeletedAt = DateTime.Now;
			blog.IsActive = false;
			blog.IsDeleted = true;
			_context.SaveChanges();
		}
	}
}
