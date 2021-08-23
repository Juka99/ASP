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
	public class EfGetLogsQuery : IGetLogsQuery
	{
		private readonly AspProjekatContext _context;

		public EfGetLogsQuery(AspProjekatContext context)
		{
			_context = context;
		}
		public int Id => 21;

		public string Name => "Get Logs by search";

		public PagedResponse<LogDto> Execute(LogSearch search)
		{
			var query = _context.UseCaseLogs.AsQueryable();

			if (!string.IsNullOrEmpty(search.UseCaseName) || !string.IsNullOrWhiteSpace(search.UseCaseName))
			{
				query = query.Where(x => x.UseCaseName.ToLower().Contains(search.UseCaseName.ToLower()));
			}

			var skipCount = search.PerPage * (search.Page - 1);

			var response = new PagedResponse<LogDto>
			{
				CurrentPage = search.Page,
				ItemsPerPage = search.PerPage,
				TotalCount = query.Count(),
				Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new LogDto
				{
					Id = x.Id,
					Date = x.Date,
					UseCaseName = x.UseCaseName,
					Data = x.Data,
					Actor = x.Actor
				}).ToList()
			};

			return response;
		}
	}
}
