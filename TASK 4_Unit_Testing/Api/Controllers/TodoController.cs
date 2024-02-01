using Api.Services;
using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("[Controller]")]
public class TodoController:ControllerBase{
    private readonly ITodoService _todo;
    public TodoController(ITodoService todo)
    {
        _todo = todo;
    }
    [HttpGet]
    [Route("Get")]
    public async Task<IActionResult>GetAllAsync(){
        var result = await _todo.GetAllAsync();
        if(result.Count==0){
            return NoContent();
        }
        return Ok(result);
    }

    [HttpPost]
    [Route("Save")]
    public async Task<IActionResult> SaveAsync(Todo lists){
        await _todo.SaveAsync(lists);
        return Ok();
    }
}