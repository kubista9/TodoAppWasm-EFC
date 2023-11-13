using System.Text.Json.Serialization;

namespace Shared.Models;

public class User
{
	public int Id { get; set; }
	public string? UserName { get; set; }
	[JsonIgnore]
	public List<Todo>? Todos { get; set; }
}
