using AspProjekat.Application.DataTransfer;
using AspProjekat.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspProjekat.Implementation.Validation
{
	public class CreateBlogValidator : AbstractValidator<BlogDto>
	{
		public CreateBlogValidator(AspProjekatContext context)
		{
			RuleFor(x => x.Name).NotEmpty();
			RuleFor(x => x.Description).NotEmpty();
		}
	}
}
