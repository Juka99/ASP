using AspProjekat.Application.Commands;
using AspProjekat.Application.Exceptions;
using AspProjekat.DataAccess;
using AspProjekat.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspProjekat.Implementation.Commands
{
	public class EfDeleteCommentCommand : IDeleteCommentCommand
	{
		private readonly AspProjekatContext _context;

		public EfDeleteCommentCommand(AspProjekatContext context)
		{
			_context = context;
		}

		public int Id => 18;

		public string Name => "Delete comment";

		public void Execute(int id)
		{
			var comment = _context.Comments.Find(id);

			if (comment == null)
			{
				throw new EntityNotFoundException(id, typeof(Comment));
			}

			if (comment.IsDeleted == true)
			{
				throw new AlreadyDeletedException(id, typeof(Comment));
			}

			comment.DeletedAt = DateTime.Now;
			comment.IsActive = false;
			comment.IsDeleted = true;

			_context.SaveChanges();
		}
	}
}
