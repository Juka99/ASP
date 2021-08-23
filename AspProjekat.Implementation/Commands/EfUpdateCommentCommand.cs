using AspProjekat.Application.Commands;
using AspProjekat.Application.DataTransfer;
using AspProjekat.Application.Exceptions;
using AspProjekat.DataAccess;
using AspProjekat.Domain;
using AspProjekat.Implementation.Validation;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspProjekat.Implementation.Commands
{
	public class EfUpdateCommentCommand : IUpdateCommentCommand
	{
		private readonly AspProjekatContext _context;
		private readonly CreateCommentValidator _validator;

		public EfUpdateCommentCommand(AspProjekatContext context, CreateCommentValidator validator)
		{
			_context = context;
			_validator = validator;
		}

		public int Id => 19;

		public string Name => "Update comment";

		public void Execute(CommentDto request, int id)
		{
			var comment = _context.Comments.Find(id);

			if (comment == null)
			{
				throw new EntityNotFoundException(id, typeof(Comment));
			}

			_validator.ValidateAndThrow(request);

			comment.Text = request.Text;
			comment.ModifiedAt = DateTime.Now;
			_context.SaveChanges();
		}
	}
}
