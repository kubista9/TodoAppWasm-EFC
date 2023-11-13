using Application.DaoInterfaces;
using Shared.DTOs;
using Shared.Models;

namespace FileData.DAOs;

public class TodoFileDao : ITodoDao
{
	private readonly FileContext _context;

	public TodoFileDao(FileContext context)
	{
		this._context = context;
	}

	public Task<Todo> CreateAsync(Todo todo)
	{
		int id = 1;
		if (_context.Todos.Any())
		{
			id = _context.Todos.Max(t => t.Id);
			id++;
		}

		todo.Id = id;

		_context.Todos.Add(todo);
		_context.SaveChanges();

		return Task.FromResult(todo);
	}

	public Task<IEnumerable<Todo>> GetAsync(SearchTodoParametersDto searchParams)
	{
		IEnumerable<Todo> result = _context.Todos.AsEnumerable();

		if (!string.IsNullOrEmpty(searchParams.Username))
		{
			// we know username is unique, so just fetch the first
			result = _context.Todos.Where(todo =>
				todo.Owner.UserName.Equals(searchParams.Username, StringComparison.OrdinalIgnoreCase));
		}

		if (searchParams.UserId != null)
		{
			result = result.Where(t => t.Owner.Id == searchParams.UserId);
		}

		if (searchParams.CompletedStatus != null)
		{
			result = result.Where(t => t.IsCompleted == searchParams.CompletedStatus);
		}

		if (!string.IsNullOrEmpty(searchParams.TitleContains))
		{
			result = result.Where(t =>
				t.Title.Contains(searchParams.TitleContains, StringComparison.OrdinalIgnoreCase));
		}

		return Task.FromResult(result);
	}

	public Task<Todo?> GetByIdAsync(int todoId)
	{
		Todo? existing = _context.Todos.FirstOrDefault(t => t.Id == todoId);
		return Task.FromResult(existing);
	}

	public Task UpdateAsync(Todo toUpdate)
	{
		Todo? existing = _context.Todos.FirstOrDefault(todo => todo.Id == toUpdate.Id);
		if (existing == null)
		{
			throw new Exception($"Todo with id {toUpdate.Id} does not exist!");
		}

		_context.Todos.Remove(existing);
		_context.Todos.Add(toUpdate);

		_context.SaveChanges();

		return Task.CompletedTask;
	}

}
