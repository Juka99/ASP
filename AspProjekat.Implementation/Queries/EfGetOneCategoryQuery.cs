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
	public class EfGetOneCategoryQuery : IGetOneCategoriesQuery
	{
		private readonly AspProjekatContext _context;

		public EfGetOneCategoryQuery(AspProjekatContext context)
		{
			_context = context;
		}

		public int Id => 6;

		public string Name => "Get one category";

		public CategoryDto Execute(int search)
		{
			var category = _context.Categories.Find(search);

			if (category == null)
			{
				throw new EntityNotFoundException(search, typeof(Category));
			}

			var result = new CategoryDto
			{
				Id = category.Id,
				Name = category.Name
			};

			return result;
		}
	}
}
