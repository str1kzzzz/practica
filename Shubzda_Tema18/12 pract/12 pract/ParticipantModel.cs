namespace _12_pract
{
    public class ParticipantModel
    {
        public int Id { get; set; }                     
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Section { get; set; }
        public int EventId { get; set; }
        public EventModel Event { get; set; }

        public override string ToString()
        {
            return $"{FullName} — {Section}";
        }
    }
}
