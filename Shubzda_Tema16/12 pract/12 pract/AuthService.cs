using System.Linq;
using System.Threading.Tasks;

namespace _12_pract
{
    public class AuthService
    {
        private readonly DataStorageService _storage = new();

        public async Task<UserModel> LoginAsync(string login, string password)
        {
            var users = await _storage.LoadUsersAsync();
            return users.FirstOrDefault(u => u.Login == login && u.Password == password);
        }

        public async Task<bool> RegisterAsync(string login, string password, string role)
        {
            var users = await _storage.LoadUsersAsync();

            if (users.Any(u => u.Login == login))
                return false;

            users.Add(new UserModel
            {
                Login = login,
                Password = password,
                Role = role
            });

            await _storage.SaveUsersAsync(users);
            return true;
        }
    }
}
