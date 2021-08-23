using AspProjekat.Application.DataTransfer;
using AspProjekat.Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspProjekat.Application.Queries
{
	public interface IGetLogsQuery : IQuery<LogSearch, PagedResponse<LogDto>>
	{
	}
}
