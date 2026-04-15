using System;
using System.Collections.ObjectModel;

namespace _12_pract
{
    public class EventModel
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public ObservableCollection<ParticipantModel> Participants { get; set; } = new();
    }
}
