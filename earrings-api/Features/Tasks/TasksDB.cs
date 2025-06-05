using Dapper;
using earrings_api.Features.Notes.Models;

namespace earrings_api.Features.Tasks
{
    public class TasksDB
    {
        #region Nombres procedures

        internal const string spGetTasks = "SP_GET_TASKS";
        internal const string spCreateTask = "SP_CREATE_TASK";
        internal const string spUpdateTask = "SP_UPDATE_TASK";
        internal const string spDeleteTask = "SP_DELETE_TASK";

        #endregion

        #region Parámetros

        internal static DynamicParameters GetTasksParams(TaskFilter filter)
        {
            DynamicParameters parameters = new(new
            {
                @p_task_id = filter.TaskId,
                @p_title = filter.Title,
                @p_active = filter.Active,
                @p_date = filter.Date,
                @p_from_date = filter.FromDate,
                @p_user_id = filter.UserId
            });

            return parameters;
        }

        internal static DynamicParameters CreateTaskParams(TaskDao task)
        {
            DynamicParameters parameters = new(new
            {
                @p_description = task.Description,
                @p_created_by = task.ModificatedBy,
                @p_title = task.Title,
                @p_date = task.Date,
                @p_user_id = task.UserId
            });

            return parameters;
        }

        internal static DynamicParameters UpdateTaskParams(TaskDao task)
        {
            DynamicParameters parameters = new(new
            {
                @p_task_id = task.TaskId,
                @p_active = task.Active,
                @p_description = task.Description,
                @p_modificated_by = task.ModificatedBy,
                @p_title = task.Title,
                @p_date = task.Date,
                @p_user_id = task.UserId
            });

            return parameters;
        }

        internal static DynamicParameters DeleteTaskParams(TaskFilter filter)
        {
            DynamicParameters parameters = new(new
            {
                @p_task_id = filter.TaskId
            });

            return parameters;
        }
        #endregion
    }
}
