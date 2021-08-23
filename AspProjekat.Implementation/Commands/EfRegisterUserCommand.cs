using AspProjekat.Application.Commands;
using AspProjekat.Application.DataTransfer;
using AspProjekat.Application.Emails;
using AspProjekat.DataAccess;
using AspProjekat.Domain;
using AspProjekat.Implementation.Validation;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspProjekat.Implementation.Commands
{
	public class EfRegisterUserCommand : IRegisterUserCommand
	{
		private readonly AspProjekatContext _context;
		private readonly RegisterUserValidator _validator;
		private readonly IEmailSender _sender;

		public EfRegisterUserCommand(AspProjekatContext context, RegisterUserValidator validator, IEmailSender sender)
		{
			_context = context;
			_validator = validator;
			_sender = sender;
		}

		public int Id => 12;

		public string Name => "User registration";

		public void Execute(RegisterDto request)
		{
			_validator.ValidateAndThrow(request);

			HashSet<UserUseCase> useCases = new HashSet<UserUseCase>();
			foreach(var uucId in request.UseCasesIds)
			{
				var userUsecase = new UserUseCase
				{
					UserUseCaseId = uucId
				};
				useCases.Add(userUsecase);
			}

			_context.Users.Add(new Domain.User
			{
				FirstName = request.FirstName,
				LastName = request.LastName,
				UserName = request.Username,
				Password = request.Password,
				Email = request.Email,
				UserUseCases = useCases
			});

			_context.SaveChanges();

			_sender.Send(new SendEmailDto
			{
				Content = "<h1>Successfully registered!</h1>",
				SendTo = request.Email,
				Subject = "Registration"
			});
		}
	}
}
