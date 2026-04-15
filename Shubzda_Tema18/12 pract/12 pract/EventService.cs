using System.Collections.Generic;
using System.Threading.Tasks;

namespace _12_pract
{
    public class EventService
    {
        private readonly DataStorageService _storage = new();

        public async Task<List<EventModel>> LoadEventsAsync()
        {
            return await _storage.LoadEventsAsync();
        }

        public async Task SaveEventsAsync(IEnumerable<EventModel> eventsList)
        {
            await _storage.SaveEventsAsync(eventsList);
        }

        public async Task SendInvitationAsync(ParticipantModel participant)
        {
            await Task.Delay(3000);
        }
    }
}
