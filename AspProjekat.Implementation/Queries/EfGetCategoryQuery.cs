using AspProjekat.Application.DataTransfer;
using AspProjekat.Application.Queries;
using AspProjekat.Application.Searches;
using AspProjekat.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AspProjekat.Implementation.Queries
{
	public class EfGetCategoryQuery : IGetCategoriesQuery
	{
		private readonly AspProjekatContext _context;

		public EfGetCategoryQuery(AspProjekatContext context)
		{
			_context = context;
		}

		public int Id => 5;

		public string Name => "Category search.";

		public PagedResponse<CategoryDto> Execute(Search search)
		{
			var query = _context.Categories.AsQueryable();

			if (!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
			{
				query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
			}

			query = query.Where(x => x.IsActive == true);

			var skipCount = search.PerPage * (search.Page - 1);

			var response = new PagedResponse<CategoryDto>
			{
				CurrentPage = search.Page,
				ItemsPerPage = search.PerPage,
				TotalCount = query.Count(),
				Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new CategoryDto
				{
					Id = x.Id,
					Name = x.Name
				}).ToList()
			};

			return response;
		}
	}
}
