using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BVE5_Motor_Assistance
{
    /// <summary>
    /// PageStart.xaml 的交互逻辑
    /// </summary>
    public partial class PageStart : Page
    {
        public PageStart()
        {
            InitializeComponent();

        }
        private void StartButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OpenFIleButton(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            Frame frame = (Frame)window.FindName("frame");
            frame.Content = new PageEdit(120,"null");

        }

        private void NewFIleButton(object sender, RoutedEventArgs e)
        {
            newfilewin newfilewin = new newfilewin();

            newfilewin.Show();

        }

        private void StartButton_Click_1(object sender, RoutedEventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-us");
        }
    }
}
