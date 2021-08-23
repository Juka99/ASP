using AspProjekat.Application.DataTransfer;
using AspProjekat.Application.Exceptions;
using AspProjekat.Application.Queries;
using AspProjekat.DataAccess;
using AspProjekat.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AspProjekat.Implementation.Queries
{
	public class EfGetOneUserQuery : IGetOneUserQuery
	{
		private readonly AspProjekatContext _context;

		public EfGetOneUserQuery(AspProjekatContext context)
		{
			_context = context;
		}

		public int Id => 15;

		public string Name => "Get One User";

		public UserDto Execute(int id)
		{
			var user = _context.Users.Find(id);

			var blogs = _context.Blogs.Where(x => x.UserId == id).Select(x => new BlogUserDto
			{
				Id = x.Id,
				Name = x.Name
			}).ToList();

			if (user == null)
			{
				throw new EntityNotFoundException(id, typeof(User));
			}

			var result = new UserDto
			{
				Id = user.Id,
				FirstName = user.FirstName,
				LastName = user.LastName,
				Username = user.UserName,
				Email = user.Email,
				Blogs = blogs
			};

			return result;
		}
	}
}
