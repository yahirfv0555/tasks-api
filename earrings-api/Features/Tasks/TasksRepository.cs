using earrings_api.Features.Notes.Models;
using EarringsApi.Handlers;
using EarringsApi.Models;

namespace earrings_api.Features.Tasks
{
    public class TasksRepository
    {
        public TasksRepository() { }

        internal async Task<List<TaskDto>> GetTasks(TaskFilter filter)
        {
            var spParams = TasksDB.GetTasksParams(filter);

            try
            {
                List<TaskDto> tasks = await DapperHandler.GetFromProcedure<TaskDto>(TasksDB.spGetTasks, spParams);

                return tasks;
            }
            catch (Exception)
            {

                return [];
            }
        }

        internal async Task<Execution> CreateTask(TaskDao note)
        {
            var spParams = TasksDB.CreateTaskParams(note);
            try
            {
                Execution execution = await DapperHandler.SetFromProcedure(TasksDB.spCreateTask, spParams);

                return execution;
            } 
            catch (Exception ex)
            {
                return new()
                {
                    Successful = false,
                    Message = ex.Message,
                };
            }
        }
    }
}
