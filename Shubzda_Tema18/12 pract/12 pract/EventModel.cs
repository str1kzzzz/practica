using System;
using System.Collections.Generic;

namespace _12_pract
{
    public class EventModel
    {
        public int Id { get; set; }                     
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public List<ParticipantModel> Participants { get; set; } = new();
        public int ParticipantsCount => Participants?.Count ?? 0;
    }
}
