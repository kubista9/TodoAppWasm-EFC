using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace EfcDataAccess;

public class TodoContext : DbContext
{
	public DbSet<User> Users { get; set; }
	public DbSet<Todo> Todos { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlite("Data Source = Todo.db");
		optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
	}
}
