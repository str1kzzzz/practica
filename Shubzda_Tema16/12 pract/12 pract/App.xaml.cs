using System.Windows;

namespace _12_pract
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Window1 login = new Window1();
            login.Show();
        }
    }
}
