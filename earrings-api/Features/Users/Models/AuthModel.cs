using EarringsApi.Models;

namespace EarringsApi.Features.Users.Models
{
    public enum AuthenticationStatus
    {
        AUTHENTICATED = 1,
        NOT_AUTHENTICATED = 2,
        NON_EXISTENT_USER = 3,
        INACTIVE_USER = 4
    }

    public class SignUpSession
    {
        public required string Code { get; set; }
        public required string Password { get; set; }
        public required UserDao User { get; set; }
    }

    public class LoginSession
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }

    public class LoginExecution : Execution
    {
        public UserDto? User { get; set; }
        public string? Jwt { get; set; }
    }
}
