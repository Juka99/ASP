using System;
using System.Collections.Generic;
using AspProjekat.Application.Queries;
using System.Text;
using AspProjekat.Application.DataTransfer;
using AspProjekat.Application.Searches;
using AspProjekat.DataAccess;
using System.Linq;

namespace AspProjekat.Implementation.Queries
{
	public class EfGetUsersQuery : IGetUsersQuery
	{
		private readonly AspProjekatContext _context;

		public EfGetUsersQuery(AspProjekatContext context)
		{
			_context = context;
		}

		public int Id => 14;

		public string Name => "Get users";

		public PagedResponse<UserDto> Execute(UserSearch search)
		{
			var query = _context.Users.AsQueryable();

			if (!string.IsNullOrEmpty(search.FirstName) || !string.IsNullOrWhiteSpace(search.FirstName))
			{
				query = query.Where(x => x.FirstName.ToLower().Contains(search.FirstName.ToLower()));
			}

			query = query.Where(x => x.IsActive == true);

			var skipCount = search.PerPage * (search.Page - 1);

			var response = new PagedResponse<UserDto>
			{
				CurrentPage = search.Page,
				ItemsPerPage = search.PerPage,
				TotalCount = query.Count(),
				Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new UserDto
				{
					Id = x.Id,
					FirstName = x.FirstName,
					LastName = x.LastName,
					Username = x.UserName,
					Email = x.Email
				}).ToList()
			};

			foreach (var user in response.Items)
			{
				user.Blogs = _context.Blogs.Where(b => b.UserId == user.Id).Select(b => new BlogUserDto
				{
					Id = b.Id,
					Name = b.Name
				}).ToList();
			}

			return response;
		}
	}
}
