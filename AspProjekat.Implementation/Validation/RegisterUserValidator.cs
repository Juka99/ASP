using AspProjekat.Application.DataTransfer;
using AspProjekat.DataAccess;
using AspProjekat.Domain;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AspProjekat.Implementation.Validation
{
	public class RegisterUserValidator : AbstractValidator<RegisterDto>
	{
		public RegisterUserValidator(AspProjekatContext context)
		{
			RuleFor(x => x.FirstName).NotEmpty();
			RuleFor(x => x.LastName).NotEmpty();
			RuleFor(x => x.Password).MinimumLength(5).NotEmpty().WithMessage("Password must be with atleast 5 characters and not empty!");
			RuleFor(x => x.Username).NotEmpty().MinimumLength(4)
									.Must(x => !context.Users.Any(user => user.UserName == x))
									.WithMessage("Username must be with atleast 4 characters and not empty and must be unique!");
			RuleFor(x => x.Email).NotEmpty().EmailAddress().Must(x => !context.Users.Any(user => user.Email == x)).WithMessage("Email adress must be unique!");
		}
	}
}
