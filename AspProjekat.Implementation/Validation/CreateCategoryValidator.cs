using AspProjekat.Application.DataTransfer;
using AspProjekat.DataAccess;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace AspProjekat.Implementation.Validation
{
	public class CreateCategoryValidator : AbstractValidator<CategoryDto>
	{
		public CreateCategoryValidator(AspProjekatContext context)
		{
			RuleFor(x => x.Name).NotEmpty().Must(name => !context.Categories.Any(g => g.Name == name)).WithMessage("Category name must be uniqe!");
		}
	}
}
