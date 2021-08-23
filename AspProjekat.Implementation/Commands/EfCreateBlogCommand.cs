using AspProjekat.Application;
using AspProjekat.Application.Commands;
using AspProjekat.Application.DataTransfer;
using AspProjekat.DataAccess;
using AspProjekat.Domain;
using AspProjekat.Implementation.Validation;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AspProjekat.Implementation.Commands
{
	public class EfCreateBlogCommand : ICreateBlogCommand
	{
		private readonly AspProjekatContext _context;
		private readonly CreateBlogValidator _validator;
		private readonly IApplicationActor actor;

		public EfCreateBlogCommand(AspProjekatContext context, CreateBlogValidator validator, IApplicationActor actor)
		{
			_context = context;
			_validator = validator;
			this.actor = actor;
		}
		public int Id => 7;

		public string Name => "Create new Blog.";

		public void Execute(BlogDto request)
		{
			_validator.ValidateAndThrow(request);

			ICollection<BlogCategory> categoryBlogs = new List<BlogCategory>();
			foreach (var catId in request.CategoryIds)
			{
				var blogCategory = new BlogCategory
				{
					CategoryId = catId
				};
				categoryBlogs.Add(blogCategory);
			}

			var blog = new Blog
			{
				Name = request.Name,
				Description = request.Description,
				BlogCategories = categoryBlogs,
				UserId = actor.Id
			};

			_context.Blogs.Add(blog);
			_context.SaveChanges();
		}
	}
}
