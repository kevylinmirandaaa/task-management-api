using Microsoft.AspNetCore.Mvc;

namespace TaskManagement.Api.Controllers;

[ApiController]
[Route("api/tasks")]
public class TasksController : ControllerBase
{
    [HttpGet]
    public IActionResult GetTasks()
    {
        var tasks = new[]
        {
            new { Id = 1, Title = "Study C#", Completed = false },
            new { Id = 2, Title = "Learn ASP.NET Core", Completed = false },
            new { Id = 3, Title = "Build my first API", Completed = true }
        };

        return Ok(tasks);
    }
}