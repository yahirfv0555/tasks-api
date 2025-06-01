namespace earrings_api.Features.Notes.Models
{
    public class Task
    {
        public int TaskId { get; set; }
        public string Description { get; set; } = "";
        public bool Active { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime Modification_Date { get; set; } 
        public int ModificatedBy { get; set; }
        public string Title { get; set; } = "";
        public DateTime Date { get; set; } = DateTime.Now;
        public int? User_Id { get; set; }
    }

    public class TaskDto
    {
        public int TaskId { get; set; }
        public string Description { get; set; } = "";
        public string Title { get; set; } = "";
        public DateTime Date { get; set; } = DateTime.Now;
        public int UserId { get; set; }
        public string UserName { get; set; } = "";
    }

    public class TaskDao
    {
        public int? TaskId { get; set; }
        public string? Description { get; set; } = "";
        public int ModificatedBy { get; set; }
        public string? Title { get; set; } = "";
        public DateTime Date { get; set; } = DateTime.Now;
        public int? UserId { get; set; }
    }

    public class TaskFilter
    {
        public int? TaskId { get; set; }
        public bool? Active { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? FromDate { get; set; }
        public int? UserId { get; set; }
    }
}
