using AspProjekat.Application.DataTransfer;
using AspProjekat.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspProjekat.Implementation.Validation
{
	public class UpdateBlogValidator : AbstractValidator<BlogDto>
	{
		public UpdateBlogValidator(AspProjekatContext context)
		{
			RuleFor(x => x.Name).NotEmpty().NotNull();
			RuleFor(x => x.Description).NotEmpty().NotNull();
			RuleFor(x => x.CategoryIds).NotNull().NotEmpty();
		}
	}
}
