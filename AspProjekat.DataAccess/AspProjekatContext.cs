using AspProjekat.DataAccess.Configurations;
using AspProjekat.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace AspProjekat.DataAccess
{
	public class AspProjekatContext : DbContext
	{
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var categories = new List<Category>
            {
                new Category
                {
                    Id = 1,
                    Name = "Life",
                    IsActive = true,
                    CreatedAt = DateTime.Now
                },
                new Category
                {
                    Id = 2,
                    Name = "Pet",
                    IsActive = true,
                    CreatedAt = DateTime.Now
                },
                new Category
                {
                    Id = 3,
                    Name = "Sport",
                    IsActive = true,
                    CreatedAt = DateTime.Now
                },
                new Category
                {
                    Id = 4,
                    Name = "Music",
                    IsActive = true,
                    CreatedAt = DateTime.Now
                },
                new Category
                {
                    Id = 5,
                    Name = "Movie",
                    IsActive = true,
                    CreatedAt = DateTime.Now
                }
            };
            modelBuilder.Entity<Category>().HasData(categories);

            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new BlogConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            modelBuilder.Entity<BlogCategory>().HasKey(x => new { x.BlogId, x.CategoryId });
        }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-1OUHHLPQ\SQLEXPRESS;Initial Catalog=blogDb2;Integrated Security=True");
                        
			base.OnConfiguring(optionsBuilder);
		}

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is Entity e)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            e.IsActive = true;
                            e.CreatedAt = DateTime.Now;
                            e.IsDeleted = false;
                            e.ModifiedAt = null;
                            e.DeletedAt = null;
                            break;
                        case EntityState.Modified:
                            e.ModifiedAt = DateTime.Now;
                            break;
                    }
                }
            }

            return base.SaveChanges();
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogCategory> BlogCategory { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UseCaseLog> UseCaseLogs { get; set; }
		public DbSet<Comment> Comments { get; set; }
        public DbSet<Picture> Pictures { get; set; }
	}
}
