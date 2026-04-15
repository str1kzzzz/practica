using System.Windows;

namespace _12_pract
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new EventViewModel();
        }
    }
}
