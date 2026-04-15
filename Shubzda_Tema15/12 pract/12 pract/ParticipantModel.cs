namespace _12_pract
{
    public class ParticipantModel
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Section { get; set; }
        public override string ToString()
        {
            return $"{FullName} — {Section}";
        }
    }
}
