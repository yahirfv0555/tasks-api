using earrings_api.Features.Notes.Models;
using EarringsApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace earrings_api.Features.Tasks
{
    [EnableCors("AllowAnyOrigin")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TasksController : Controller
    {
        private readonly TasksRepository tasksRepository;
        public TasksController()
        {
            tasksRepository = new TasksRepository();
        }

        [HttpGet]
        public async Task<ActionResult<List<NoteDto>>> GetTasks([FromQuery] TaskFilter filter) 
        {
            List<TaskDto> tasks = await tasksRepository.GetTasks(filter);

            return Ok(tasks);
        }

        [HttpPost]
        public async Task<ActionResult<Execution>> CreateTask([FromBody] TaskDao task)
        {
            Execution execution = await tasksRepository.CreateTask(task);

            return execution;
        }

        [HttpPut]
        public async Task<ActionResult<Execution>> UpdateTask([FromBody] TaskDao task)
        {
            Execution execution = await tasksRepository.UpdateTask(task);

            return execution;
        }

        [HttpDelete]
        public async Task<ActionResult<Execution>> DeleteTask([FromBody] TaskFilter filter)
        {
            Execution execution = await tasksRepository.DeleteTask(filter);

            return Ok(execution);
        }

    }
}
