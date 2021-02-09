using Microsoft.EntityFrameworkCore;
using TARSTestJosue.Models;

namespace TARSTestJosue.Data
{
	public sealed class ApplicationContext : DbContext
	{
		public ApplicationContext(DbContextOptions options) : base(options)
		{
			this.ChangeTracker.LazyLoadingEnabled = false;
		}
		public DbSet<Component> Cocmponents { get; set; }
		public DbSet<Item> Items { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
		}
	}
}
