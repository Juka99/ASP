using AspProjekat.Application;
using AspProjekat.Application.Commands;
using AspProjekat.Application.Exceptions;
using AspProjekat.DataAccess;
using AspProjekat.Domain;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace AspProjekat.Implementation.Commands
{
	public class EfDeleteUserCommand : IDeleteUserCommand
	{
		private readonly AspProjekatContext _context;
		private readonly IApplicationActor _actor;

		public EfDeleteUserCommand(AspProjekatContext context, IApplicationActor actor)
		{
			_context = context;
			_actor = actor;
		}

		public int Id => 13;

		public string Name => "Delete user";

		public void Execute(int id)
		{
			var user = _context.Users.Find(id);

			if (user.Id == _actor.Id)
			{
				throw new DeleteYourselfException(id, typeof(User));
			}

			if (user == null)
			{
				throw new EntityNotFoundException(id, typeof(User));
			}

			if (user.IsDeleted == true)
			{
				throw new AlreadyDeletedException(id, typeof(User));
			}

			user.DeletedAt = DateTime.Now;
			user.IsActive = false;
			user.IsDeleted = true;
			_context.SaveChanges();
		}
	}
}
