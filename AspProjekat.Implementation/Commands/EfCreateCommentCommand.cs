using AspProjekat.Application;
using AspProjekat.Application.Commands;
using AspProjekat.Application.DataTransfer;
using AspProjekat.DataAccess;
using AspProjekat.Domain;
using AspProjekat.Implementation.Validation;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AspProjekat.Implementation.Commands
{
	public class EfCreateCommentCommand : ICreateCommentCommand
	{
		private readonly AspProjekatContext _context;
		private readonly IApplicationActor _actor;
		private readonly CreateCommentValidator _validator;

		public EfCreateCommentCommand(AspProjekatContext context, IApplicationActor actor, CreateCommentValidator validator)
		{
			_context = context;
			_actor = actor;
			_validator = validator;
		}

		public int Id => 17;

		public string Name => "Create comment";

		public void Execute(CommentDto request, int id)
		{
			_validator.ValidateAndThrow(request);

			var comment = new Comment
			{
				Text = request.Text,
				BlogId = id,
				UserId = _actor.Id
			};

			_context.Comments.Add(comment);
			_context.SaveChanges();
		}
	}
}
