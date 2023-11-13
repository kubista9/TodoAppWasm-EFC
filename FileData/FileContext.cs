using System.Text.Json;
using Shared.Models;

namespace FileData;

public class FileContext
{
	private const string FilePath = "data.json";

	private DataContainer? _dataContainer;

	public ICollection<Todo>? Todos
	{
		get
		{
			LazyLoadData();
			return _dataContainer?.Todos;
		}
	}

	public ICollection<User>? Users
	{
		get
		{
			LazyLoadData();
			return _dataContainer?.Users;
		}
	}

	private void LazyLoadData()
	{
		if (_dataContainer != null) return;

		if (!File.Exists(FilePath))
		{
			_dataContainer = new ()
			{
				Todos = new List<Todo>(),
				Users = new List<User>()
			};
			return;
		}
		string content = File.ReadAllText(FilePath);
		_dataContainer = JsonSerializer.Deserialize<DataContainer>(content);
	}

	public void SaveChanges()
	{
		string serialized = JsonSerializer.Serialize(_dataContainer, new JsonSerializerOptions
		{
			WriteIndented = true
		});
		File.WriteAllText(FilePath, serialized);
		_dataContainer = null;
	}
}
