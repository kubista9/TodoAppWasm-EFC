using Application.LogicInterfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;
using Shared.Models;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TodosController : ControllerBase
{
	private readonly ITodoLogic _todoLogic;

	public TodosController(ITodoLogic todoLogic)
	{
		this._todoLogic = todoLogic;
	}

	[HttpPost]
	public async Task<ActionResult<Todo>> CreateAsync([FromBody]TodoCreationDto dto)
	{
		try
		{
			Todo created = await _todoLogic.CreateAsync(dto);
			return Created($"/todos/{created.Id}", created);
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			return StatusCode(500, e.Message);
		}
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<Todo>>> GetAsync([FromQuery] string? userName, [FromQuery] int? userId,
		[FromQuery] bool? completedStatus, [FromQuery] string? titleContains)
	{
		try
		{
			SearchTodoParametersDto parameters = new(userName, userId, completedStatus, titleContains);
			var todos = await _todoLogic.GetAsync(parameters);
			return Ok(todos);
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			return StatusCode(500, e.Message);
		}
	}

	[HttpPatch]
	public async Task<ActionResult> UpdateAsync([FromBody] TodoUpdateDto dto)
	{
		try
		{
			await _todoLogic.UpdateAsync(dto);
			return Ok();
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			return StatusCode(500, e.Message);
		}
	}
}
