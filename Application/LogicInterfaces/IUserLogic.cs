using Shared.DTOs;
using Shared.Models;

namespace Application.LogicInterfaces;

public interface IUserLogic
{
	Task<User> CreateAsync(UserCreationDto userToCreate);
	public Task<IEnumerable<User>> GetAsync(SearchUserParametersDto searchParameters);
}
