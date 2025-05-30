namespace EarringsApi.Features.Users.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name{ get; set; } = "";
        public bool Active { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime Modification_Date { get; set; }
        public int ModificatedBy { get; set; }
        public string Email { get; set; } = "";
        public byte[] PasswordHash { get; set; } = [];
        public byte[] PasswordSalt { get; set; } = [];
    }

    public class UserDto
    {
        public int UserId { get; set; }
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
    }

    public class UserDao
    {
        public int? UserId { get; set; }
        public string? Name { get; set; } = "";
        public int? ModificatedBy { get; set; }
        public string? Email { get; set; } = "";
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
    }

    public class UserFilter
    {
        public int? UserId { get; set; }
        public bool? Active { get; set; }
        public string? Email { get; set; }
        public bool? BringPassword { get; set; }
    }

}
