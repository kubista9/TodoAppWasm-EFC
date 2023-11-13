using Shared.Models;

namespace FileData;

public class DataContainer
{
	public ICollection<User> Users { get; set; } = new List<User>();
	public ICollection<Todo> Todos { get; set; } = new List<Todo>();
}
