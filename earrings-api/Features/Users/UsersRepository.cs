using earrings_api.Features.Notes;
using earrings_api.Middleware;
using EarringsApi.Features.Users.Models;
using EarringsApi.Handlers;
using EarringsApi.Models;

namespace EarringsApi.Features.Users
{
    public class UsersRepository
    {
        internal readonly CipherHandler cipherHandler;
        internal readonly Auth auth;
        public UsersRepository() 
        {
            cipherHandler = new();
            auth = new();
        }

        internal async Task<LoginExecution> Login(LoginSession loginSession)
        {
            try
            {
                UserFilter userFilter = new()
                {
                    Email = loginSession.Email,
                    Active = true,
                    BringPassword = true
                };

                List<UserDto> users = await GetUsers(userFilter);

                if (users.Count == 0)
                {
                    return new()
                    {
                        Successful = false,
                        Message = "No existe ningun usuario vinculado a este email",
                    };
                }

                UserDto user = users[0];

                var authentication = cipherHandler.ComparePasswords(user.PasswordHash, user.PasswordSalt, loginSession.Password); 

                if (authentication == AuthenticationStatus.AUTHENTICATED)
                {
                    string jwt = auth.GetJwt(user);

                    user.PasswordHash = null;
                    user.PasswordSalt = null;

                    return new()
                    {
                        Successful = true,
                        Message = "Credenciales correctas",
                        User = user,
                        Jwt = jwt
                    };
                }
                else
                {
                    return new()
                    {
                        Successful = false,
                        Message = "Credenciales incorrectas",
                    };
                }

            }
            catch (Exception ex)
            {
                return new()
                {
                    Successful = false,
                    Message = ex.Message
                };
            }
        }

        internal async Task<List<UserDto>> GetUsers(UserFilter filter)
        {
            var spParms = UsersDB.GetUsersParams(filter);

            try
            {
                List<UserDto> users = await DapperHandler.GetFromProcedure<UserDto>(UsersDB.spGetUsers, spParms);

                return users;
            }
            catch (Exception)
            {
                return [];
            }
        }

        internal async Task<LoginExecution> SignUp(SignUpSession signUpSession)
        {
            try
            {
                UserDao user = signUpSession.User;

                (user.PasswordHash, user.PasswordSalt) = cipherHandler.HashPassword(signUpSession.Password);

                Execution execution = await CreateUser(user);

                if (!execution.Successful)
                {
                    return (LoginExecution)execution;
                }

                LoginSession loginSession = new() 
                {
                    Email = user.Email!,
                    Password = signUpSession.Password
                };

                LoginExecution loginExecution = await Login(loginSession);

                return new()
                {
                    User = new()
                    {
                        UserId = execution.Id ?? 0,
                        Email = user.Email!,
                        Name = user.Name!,
                    },
                    Jwt = loginExecution.Jwt,
                    Successful  = loginExecution.Successful,
                    Message = loginExecution.Successful ? "Usuario creado correctamente" : "Ocurrió un error al iniciar sesión"
                };
            }
            catch (Exception ex)
            {
                return new()
                {
                    Successful = false,
                    Message = ex.Message
                };
            }
        }

        private async Task<Execution> CreateUser(UserDao user)
        {
            var spParams = UsersDB.CreateUserParams(user);

            try
            {

                Execution execution = await DapperHandler.SetFromProcedure(UsersDB.spCreateUser, spParams);

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
