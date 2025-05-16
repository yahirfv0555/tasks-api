namespace EarringsApi.Models
{
    public class Execution
    {
        public bool Successful { get;set; }
        public string Message { get; set; } = "";
        public int? Id { get; set; }
    }
}
