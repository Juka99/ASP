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
	public class EfUpdateUserCommand : IUpdateUserCommand
	{
		private readonly AspProjekatContext _context;
		private readonly UpdateUserValidator _validator;

		public EfUpdateUserCommand(AspProjekatContext context, UpdateUserValidator validator)
		{
			_context = context;
			_validator = validator;
		}

		public int Id => 16;

		public string Name => "Update user";

		public void Execute(UserUpdateDto request, int id)
		{
			var user = _context.Users.Find(id);

			if (user == null)
			{
				throw new EntityNotFoundException(id, typeof(User));
			}

			_validator.ValidateAndThrow(request);

			user.FirstName = request.FirstName;
			user.LastName = request.LastName;
			user.UserName = request.Username;
			user.Email = request.Email;
			user.ModifiedAt = DateTime.Now;

			_context.SaveChanges();
		}
	}
}
