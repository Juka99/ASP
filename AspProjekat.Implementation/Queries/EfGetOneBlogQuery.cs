using AspProjekat.Application.DataTransfer;
using AspProjekat.Application.Exceptions;
using AspProjekat.Application.Queries;
using AspProjekat.DataAccess;
using AspProjekat.Domain;
using System.Collections.Generic;
using System.Linq;

namespace AspProjekat.Implementation.Queries
{
	public class EfGetOneBlogQuery : IGetOneBlogQuery
	{
		private readonly AspProjekatContext _context;

		public EfGetOneBlogQuery(AspProjekatContext context)
		{
			_context = context;
		}
		public int Id => 10;

		public string Name => "Display one blog.";

		public BlogDto Execute(int id)
		{
			var blog = _context.Blogs.Find(id);

			var categoryIds = _context.BlogCategory.Where(x => x.BlogId == id).Select(x => x.CategoryId).ToList();
			var images = _context.Pictures.Where(p => p.BlogId == id).Select(p => p.Src).ToList();

			if (blog == null)
			{
				throw new EntityNotFoundException(id, typeof(Blog));
			}

			var result = new BlogDto
			{
				Id = blog.Id,
				Name = blog.Name,
				Description = blog.Description,
				CategoryIds = categoryIds,
				Images = images
			};
			return result;
		}
	}
}
