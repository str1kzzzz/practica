using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;

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
            WindowState = WindowState.Maximized;
        }
        private void Row_Loaded(object sender, RoutedEventArgs e)
        {
            if (sender is DataGridRow row)
            {
                if (Resources["FadeInRow"] is Storyboard sb)
                    sb.Begin(row);
            }
        }
        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (DataContext is EventViewModel vm && vm.SelectedEvent != null)
            {
                var ev = vm.SelectedEvent;

                MessageBox.Show(
                    $"Название: {ev.Name}\n" +
                    $"Дата: {ev.Date:dd.MM.yyyy}\n" +
                    $"Участников: {ev.Participants.Count}",
                    "Детали мероприятия",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information
                );
            }
        }
    }
}