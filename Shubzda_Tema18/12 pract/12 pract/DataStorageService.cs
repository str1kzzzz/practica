using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace _12_pract
{
    public class DataStorageService
    {
        private const string EventsFile = "events.json";
        private const string UsersFile = "users.json";

        public async Task<List<EventModel>> LoadEventsAsync()
        {
            if (!File.Exists(EventsFile))
                return new List<EventModel>();

            using var stream = File.OpenRead(EventsFile);
            return await JsonSerializer.DeserializeAsync<List<EventModel>>(stream)
                   ?? new List<EventModel>();
        }

        public async Task SaveEventsAsync(IEnumerable<EventModel> eventsList)
        {
            using var stream = File.Create(EventsFile);
            await JsonSerializer.SerializeAsync(stream, eventsList,
                new JsonSerializerOptions { WriteIndented = true });
        }

        public async Task<List<UserModel>> LoadUsersAsync()
        {
            if (!File.Exists(UsersFile))
                return new List<UserModel>();

            using var stream = File.OpenRead(UsersFile);
            return await JsonSerializer.DeserializeAsync<List<UserModel>>(stream)
                   ?? new List<UserModel>();
        }

        public async Task SaveUsersAsync(IEnumerable<UserModel> users)
        {
            using var stream = File.Create(UsersFile);
            await JsonSerializer.SerializeAsync(stream, users,
                new JsonSerializerOptions { WriteIndented = true });
        }
    }
}
