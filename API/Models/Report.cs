namespace TaskSync.Models
{
    public class Report
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public string Summary { get; set; }
        public DateTime GeneratedDate { get; set; }
    }
}