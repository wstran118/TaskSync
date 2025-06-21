namespace TaskSync.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int AssigneeId { get; set; }
        public string Status { get; set; } // e.g., Pending, InProgress, Completed
        public DateTime DueDate { get; set; }
    }
}