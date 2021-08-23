using AspProjekat.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspProjekat.DataAccess.Configurations
{
	public class BlogConfiguration : IEntityTypeConfiguration<Blog>
	{
		public void Configure(EntityTypeBuilder<Blog> builder)
		{
			builder.Property(x => x.Name).HasMaxLength(30);
			builder.HasIndex(x => x.Id).IsUnique();
			builder.Property(x => x.Name).IsRequired();
			builder.Property(x => x.Description).IsRequired();

			builder.HasMany(b => b.BlogCategories).WithOne(cb => cb.Blog).HasForeignKey(x => x.BlogId).OnDelete(DeleteBehavior.Restrict);
		}
	}
}
