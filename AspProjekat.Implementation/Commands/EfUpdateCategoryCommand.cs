using AspProjekat.Application.Commands;
using AspProjekat.Application.DataTransfer;
using AspProjekat.Application.Exceptions;
using AspProjekat.DataAccess;
using AspProjekat.Domain;
using AspProjekat.Implementation.Validation;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspProjekat.Implementation.Commands
{
	public class EfUpdateCategoryCommand : IUpdateCategoryCommand
	{
		private readonly AspProjekatContext _context;
		private readonly CreateCategoryValidator _validator;

		public EfUpdateCategoryCommand(AspProjekatContext context, CreateCategoryValidator validator)
		{
			_context = context;
			_validator = validator;
		}
		public int Id => 3;

		public string Name => "Update category.";

		public void Execute(CategoryDto request, int id)
		{
			var category = _context.Categories.Find(id);

			if (category == null)
			{
				throw new EntityNotFoundException(id, typeof(Category));
			}

			_validator.ValidateAndThrow(request);

			category.Name = request.Name;
			category.ModifiedAt = DateTime.Now;
			_context.SaveChanges();
		}
	}
}
