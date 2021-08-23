using AspProjekat.Application.DataTransfer;
using AspProjekat.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AspProjekat.Implementation.Validation
{
	public class UpdateUserValidator : AbstractValidator<UserUpdateDto>
	{
		public UpdateUserValidator(AspProjekatContext context)
		{
			RuleFor(x => x.FirstName).NotEmpty().NotNull();
			RuleFor(x => x.LastName).NotEmpty().NotNull();
			RuleFor(x => x.Username).NotEmpty().MinimumLength(4)
									.Must(x => !context.Users.Any(user => user.UserName == x))
									.WithMessage("Username must be with atleast 4 characters and not empty and must be unique!");
			RuleFor(x => x.Email).NotEmpty().EmailAddress();
		}
	}
}
