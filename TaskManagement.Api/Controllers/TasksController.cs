using Microsoft.AspNetCore.Mvc;
using TaskManagement.Api.Models;

namespace TaskManagement.Api.Controllers;

[ApiController]
[Route("api/tasks")]
public class TasksController : ControllerBase
{
    private static readonly List<TaskItem> tasks = new()
    {
        new TaskItem { Id = 1, Title = "Study C#", Completed = false },
        new TaskItem { Id = 2, Title = "Learn ASP.NET Core", Completed = false },
        new TaskItem { Id = 3, Title = "Build my first API", Completed = true }
    };

    [HttpGet]
    public IActionResult GetTasks()
    {
        return Ok(tasks);
    }

    [HttpPost]
    public IActionResult CreateTask([FromBody] TaskItem task)
    {
        if (string.IsNullOrWhiteSpace(task.Title))
        {
            return BadRequest("Task title is required.");
        }

        task.Id = tasks.Count == 0 ? 1 : tasks.Max(t => t.Id) + 1;
        task.Completed = false;
        tasks.Add(task);

        return Created($"/api/tasks/{task.Id}", task);
    }
}