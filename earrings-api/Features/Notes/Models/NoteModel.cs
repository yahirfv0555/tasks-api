namespace earrings_api.Features.Notes.Models
{
    public class Note
    {
        public int NoteId { get; set; }
        public string Value { get; set; } = "";
        public DateTime CreationDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime Modification_Date { get; set; } 
        public int ModificatedBy { get; set; }
        public string Title { get; set; } = "";
    }

    public class NoteDto
    {
        public int NoteId { get; set; }
        public string Value { get; set; } = "";
        public string Title { get; set; } = "";
    }

    public class NoteDao
    {
        public int? NoteId { get; set; }
        public string? Value { get; set; } = "";
        public int Modificated_By { get; set; }
        public string? Title { get; set; } = "";
    }
}
