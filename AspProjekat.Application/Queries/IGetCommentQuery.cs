using AspProjekat.Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspProjekat.Application.Queries
{
	public interface IGetCommentQuery : IQuery<int, CommentGetDto>
	{
	}
}
