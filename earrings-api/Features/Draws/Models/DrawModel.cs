namespace EarringsApi.Features.Draws.Models
{
    public class Draw
    {
        public int DrawId { get; set; }
        public string Image { get; set; } = "";
        public bool Active { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime Modification_Date { get; set; }
        public int ModificatedBy { get; set; }
        public string Title { get; set; } = "";
        public int UserId { get; set; }
        public string Tag { get; set; } = "";
    }

    public class DrawDto
    { 
        public int DrawId { get; set; }
        public string Image { get; set; } = "";
        public string Title { get; set; } = "";
        public int UserId { get; set; }
        public string Tag { get; set; } = "";
    }

    public class DrawDao
    {
        public int? DrawId { get; set; }
        public bool? Active { get; set; }
        public string? Image { get; set; }
        public int ModificatedBy { get; set; }
        public string? Title { get; set; }
        public int? UserId { get; set; }
        public string? Tag { get; set; }

    }

    public class DrawFilter
    {
        public int? DrawId { get; set; }
        public bool? Active { get; set; }
        public string? Title { get; set; }
        public int? UserId { get; set; }
        public string? Tags { get; set; }
    }
}
