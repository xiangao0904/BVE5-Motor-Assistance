using System.Configuration;
using System.Data;
using System.Windows;

namespace BVE5_Motor_Assistance
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh-cn");
            base.OnStartup(e);
           

        }
    }


}
