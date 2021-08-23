using AspProjekat.Application.DataTransfer;
using AspProjekat.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspProjekat.Implementation.Validation
{
	public class CreateCommentValidator : AbstractValidator<CommentDto>
	{
		public CreateCommentValidator(AspProjekatContext context)
		{
			RuleFor(x => x.Text).NotEmpty().NotNull();
		}
	}
}
