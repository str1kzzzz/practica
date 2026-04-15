using System;
using System.Collections.Generic;

namespace _12_pract
{
    public class EventItem
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public List<Participant> Participants { get; set; } = new();
    }

    public class Participant
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Section { get; set; }
        public string EventName { get; set; }

        public override string ToString()
        {
            return $"{FullName} — {Section} — {EventName}";
        }
    }
}
