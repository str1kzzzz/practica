using System.Collections.Generic;
using System.Threading.Tasks;

namespace _12_pract
{
    public class EventService
    {
        public async Task<List<EventModel>> LoadEventsAsync()
        {
            await Task.Delay(500); 

            return new List<EventModel>
            {
                new EventModel { Name = "Конференция IT", Date = System.DateTime.Now },
                new EventModel { Name = "Форум образования", Date = System.DateTime.Now.AddDays(1) }
            };
        }
        public async Task SendInvitationAsync(ParticipantModel participant)
        {
            await Task.Delay(3000);
        }
    }
}
