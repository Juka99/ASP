using AspProjekat.Application.Commands;
using AspProjekat.Application.DataTransfer;
using AspProjekat.Application.Exceptions;
using AspProjekat.DataAccess;
using AspProjekat.Domain;
using AspProjekat.Implementation.Validation;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace AspProjekat.Implementation.Commands
{
	public class EfUpdateBlogCommand : IUpdateBlogCommand
	{

		private readonly AspProjekatContext _context;
		private readonly UpdateBlogValidator _validator;

		public EfUpdateBlogCommand(AspProjekatContext context, UpdateBlogValidator validator)
		{
			_context = context;
			_validator = validator;
		}
		public int Id => 9;

		public string Name => "Update blog";

		public void Execute(BlogDto request, int id)
		{
			var blog = _context.Blogs.Find(id);
			
			if (blog == null)
			{
				throw new EntityNotFoundException(id, typeof(Blog));
			}

			_context.Database.ExecuteSqlRaw($"Delete from BlogCategory where BlogId = {id}");

			_validator.ValidateAndThrow(request);

			blog.Name = request.Name;
			blog.Description = request.Description;
			blog.ModifiedAt = DateTime.Now;
			var categoryIds = request.CategoryIds;

			ICollection<BlogCategory> blogCategories = new List<BlogCategory>();

			foreach (var categoryId in categoryIds)
			{
				var blogCategory = new BlogCategory
				{
					BlogId = id,
					CategoryId = categoryId
				};
				blogCategories.Add(blogCategory);
			}
			blog.BlogCategories = blogCategories;
			_context.SaveChanges();

		}
	}
}
