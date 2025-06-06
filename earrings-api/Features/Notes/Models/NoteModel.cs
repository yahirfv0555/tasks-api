namespace earrings_api.Features.Notes.Models
{
    public class Note
    {
        public int NoteId { get; set; }
        public string Description { get; set; } = "";
        public bool Active { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime Modification_Date { get; set; } 
        public int ModificatedBy { get; set; }
        public string Title { get; set; } = "";
        public int? User_Id { get; set; }
    }

    public class NoteDto
    {
        public int NoteId { get; set; }
        public string Description { get; set; } = "";
        public string Title { get; set; } = "";
        public int UserId { get; set; }
        public string UserName { get; set; } = "";
    }

    public class NoteDao
    {
        public int? NoteId { get; set; }
        public bool Active { get; set; }
        public string? Description { get; set; }
        public int ModificatedBy { get; set; }
        public string? Title { get; set; }
        public int? UserId { get; set; }
    }

    public class NoteFilter
    {
        public int? NoteId { get; set; }
        public bool? Active { get; set; }
        public int? UserId { get; set; }
        public string? Title { get; set; }
    }
}
