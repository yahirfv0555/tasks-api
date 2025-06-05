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

        internal async Task<Execution> CreateTask(TaskDao task)
        {
            var spParams = TasksDB.CreateTaskParams(task);
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

        internal async Task<Execution> UpdateTask(TaskDao task)
        {
            var spParams = TasksDB.UpdateTaskParams(task);
            try
            {
                Execution execution = await DapperHandler.SetFromProcedure(TasksDB.spUpdateTask, spParams);

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

        internal async Task<Execution> DeleteTask(TaskFilter filter)
        {
            var spParams = TasksDB.DeleteTaskParams(filter);
            try
            {
                Execution execution = await DapperHandler.SetFromProcedure(TasksDB.spDeleteTask, spParams);

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
