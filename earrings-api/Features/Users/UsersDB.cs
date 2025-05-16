using Dapper;
using earrings_api.Features.Notes.Models;
using EarringsApi.Features.Users.Models;

namespace EarringsApi.Features.Users
{
    public class UsersDB
    {
        #region Nombres procedures

        internal const string spGetUsers = "SP_GET_USERS";
        internal const string spCreateUser = "SP_CREATE_USER";

        #endregion

        #region Parámetros

        internal static DynamicParameters GetUsersParams(UserFilter filter)
        {
            DynamicParameters parameters = new(new
            {
                @p_user_id = filter.UserId,
                @p_active = filter.Active,
                @p_bring_password = filter.BringPassword,
                @p_email = filter.Email
            });

            return parameters;
        }

        internal static DynamicParameters CreateUserParams(UserDao user)
        {
            DynamicParameters parameters = new(new
            {
                @p_name = user.Name,
                @p_created_by = user.ModificatedBy,
                @p_email = user.Email,
                @p_password_hash = user.PasswordHash,
                @p_password_salt = user.PasswordSalt,
            });

            return parameters;
        }

        #endregion
    }
}
