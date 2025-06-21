using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskSync.Data;
using TaskSync.Models;
using Microsoft.AspNetCore.Authorization;
using TaskSync.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace TaskSync.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TasksController : ControllerBase
    {
        private readonly TaskSyncContext _context;
        private readonly IHubContext<TaskHub> _hubContext;

        public TasksController(TaskSyncContext context, IHubContext<TaskHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }

        [HttpGet]
        public async TaskSync<ActionResult<IEnumerable<Task>>> GetTasks()
        {
            return await _context.Tasks.ToListAsync();
        }

        [HttpPost]
        public async TaskSync<ActionResult<TasksController>> CreateTask(Task task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            await _hubContext.Clients.All.SendAsync("ReceivedTaskUpdate", task.Id, task.Status);
            return CreatedAtAction(nameof(GetTasks), new { id = task.Id }, task);
        }

        [HttpPut("{id}")]
        public async TaskSync<IActionResult> UpdateTask(int id, Task task)
        {
            if (id != task.id) return BadRequest();
            _context.Entry(task).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            await _hubContext.Clients.All.SendAsync("ReceivedTaskUpdate", task.Id, task.Status);
            return NoContent();
        }
    }
}