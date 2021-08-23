using AspProjekat.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspProjekat.DataAccess.Configurations
{
	public class CategoryConfiguration : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder.Property(x => x.Name).HasMaxLength(30);
			builder.HasIndex(x => x.Id).IsUnique();
			builder.Property(x => x.Name).IsRequired();

			builder.HasMany(c => c.CategoriesBlog).WithOne(bc => bc.Category).HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.Restrict);
		}
	}
}
