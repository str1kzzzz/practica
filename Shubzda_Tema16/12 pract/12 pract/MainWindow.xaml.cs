using System.Windows;

namespace _12_pract
{
    public partial class MainWindow : Window
    {
        public UserModel CurrentUser { get; }

        public MainWindow(UserModel user)
        {
            InitializeComponent();
            CurrentUser = user;
            DataContext = new EventViewModel();
        }
    }
}
