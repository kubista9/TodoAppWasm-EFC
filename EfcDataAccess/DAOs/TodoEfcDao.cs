using Application.DaoInterfaces;
using Shared.DTOs;
using Shared.Models;

namespace EfcDataAccess.DAOs;

public class TodoEfcDao : ITodoDao
{
	public Task<Todo> CreateAsync(Todo todo)
	{
		throw new NotImplementedException();
	}

	public Task<IEnumerable<Todo>> GetAsync(SearchTodoParametersDto searchParameters)
	{
		throw new NotImplementedException();
	}

	public Task UpdateAsync(Todo todo)
	{
		throw new NotImplementedException();
	}

	public Task<Todo?> GetByIdAsync(int todoId)
	{
		throw new NotImplementedException();
	}

	public Task DeleteAsync(int id)
	{
		throw new NotImplementedException();
	}
}
