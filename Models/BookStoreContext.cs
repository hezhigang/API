using System;
using Microsoft.EntityFrameworkCore;

namespace API.Models
{
	public class BookStoreContext : DbContext
	{

		public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder) 
		{
			modelBuilder.Entity<Category>()
			.HasMany(c => c.books)
			.WithOne(a => a.Category)
			.HasForeignKey(a => a.CategoryId);

			modelBuilder.seed();
		}

		public DbSet<Book> Books { get; set; }
		public DbSet<Category> Categories { get; set; }

	}
}