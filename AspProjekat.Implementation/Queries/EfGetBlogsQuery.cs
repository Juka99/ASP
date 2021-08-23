using AspProjekat.Application.DataTransfer;
using AspProjekat.Application.Queries;
using AspProjekat.Application.Searches;
using AspProjekat.DataAccess;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace AspProjekat.Implementation.Queries
{
	public class EfGetBlogsQuery : IGetBlogsQuery
	{
		private readonly AspProjekatContext _context;

		public EfGetBlogsQuery(AspProjekatContext context)
		{
			_context = context;
		}

		public int Id => 11;

		public string Name => "Blog search";

		public PagedResponse<BlogGetDto> Execute(Search search)
		{
			var query = _context.Blogs.AsQueryable();


			if (!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
			{
				query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
			}

			query = query.Where(x => x.IsActive == true);

			var skipCount = search.PerPage * (search.Page - 1);

			var response = new PagedResponse<BlogGetDto>
			{
				CurrentPage = search.Page,
				ItemsPerPage = search.PerPage,
				TotalCount = query.Count(),
				Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new BlogGetDto
				{
					Id = x.Id,
					Name = x.Name,
					Description = x.Description
				}).ToList()
			};

			foreach (var blog in response.Items)
			{
				blog.ImageDtos = _context.Pictures.Where(p => p.BlogId == blog.Id).Select(p => new ImageDto
				{
					Src = p.Src
				}).ToList();

				blog.Categories = _context.BlogCategory.Where(c => c.BlogId == blog.Id).Select(c => new CategoryDto
				{
					Id = c.CategoryId,
					Name = c.Category.Name
				}).ToList();
			}
				
			return response;
		}
	}
}
