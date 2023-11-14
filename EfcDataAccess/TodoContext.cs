using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace EfcDataAccess;

public class TodoContext : DbContext
{
	public DbSet<User> Users { get; set; }
	public DbSet<Todo> Todos { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlite("Data Source = ../EfcDataAccess/Todo.db");
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Todo>().HasKey(todo => todo.Id);
		modelBuilder.Entity<User>().HasKey(user => user.Id);
	}
}
