using AspProjekat.Application.Commands;
using AspProjekat.Application.Exceptions;
using AspProjekat.DataAccess;
using AspProjekat.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspProjekat.Implementation.Commands
{
	public class EfDeleteCategoryCommand : IDeleteCategoryCommand
	{
		private readonly AspProjekatContext _context;

		public EfDeleteCategoryCommand(AspProjekatContext context)
		{
			_context = context;
		}

		public int Id => 2;

		public string Name => "Deleting category.";

		public void Execute(int id)
		{
			var category = _context.Categories.Find(id);

			if (category == null)
			{
				throw new EntityNotFoundException(id, typeof(Category));
			}

			if (category.IsDeleted == true)
			{
				throw new AlreadyDeletedException(id, typeof(Category));
			}

			category.DeletedAt = DateTime.Now;
			category.IsActive = false;
			category.IsDeleted = true;
			_context.SaveChanges();
		}
	}
}
