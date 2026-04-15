namespace StudyPlanner.Models
{
    public class StudyTask
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public DateTime Deadline { get; set; }
        public bool Completed { get; set; }
    }
}
