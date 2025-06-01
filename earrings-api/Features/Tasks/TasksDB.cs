using Dapper;
using earrings_api.Features.Notes.Models;

namespace earrings_api.Features.Tasks
{
    public class TasksDB
    {
        #region Nombres procedures

        internal const string spGetTasks = "SP_GET_TASKS";
        internal const string spCreateTask = "SP_CREATE_TASK";

        #endregion

        #region Parámetros

        internal static DynamicParameters GetTasksParams(TaskFilter filter)
        {
            DynamicParameters parameters = new(new
            {
                @p_task_id = filter.TaskId,
                @p_active = filter.Active,
                @p_date = filter.Date,
                @p_from_date = filter.FromDate,
                @p_user_id = filter.UserId
            });

            return parameters;
        }

        internal static DynamicParameters CreateTaskParams(TaskDao note)
        {
            DynamicParameters parameters = new(new
            {
                @p_description = note.Description,
                @p_created_by = note.ModificatedBy,
                @p_title = note.Title,
                @p_date = note.Date,
                @p_user_id = note.UserId
            });

            return parameters;
        }

        #endregion
    }
}
