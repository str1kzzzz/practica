using System.Windows;
using System.Windows.Controls;

namespace _12_pract
{
    public partial class Window1 : Window
    {
        private readonly AuthService _auth = new();

        public Window1()
        {
            InitializeComponent();
        }

        private async void Login_Click(object sender, RoutedEventArgs e)
        {
            var login = LoginBox.Text;
            var password = PasswordBox.Password;

            var user = await _auth.LoginAsync(login, password);

            if (user == null)
            {
                MessageBox.Show("Неверный логин или пароль");
                return;
            }
            MainWindow main = new MainWindow(user);
            main.Show();
            Close();
        }

        private async void Register_Click(object sender, RoutedEventArgs e)
        {
            var login = LoginBox.Text;
            var password = PasswordBox.Password;

            bool ok = await _auth.RegisterAsync(login, password, "Participant");

            if (!ok)
            {
                MessageBox.Show("Пользователь уже существует");
                return;
            }

            MessageBox.Show("Регистрация успешна!");
        }
    }
}
