using BVE5_Motor_Assistance.Logic;
using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BVE5_Motor_Assistance
{
    /// <summary>
    /// newfilewin.xaml 的交互逻辑
    /// </summary>
    public partial class newfilewin : Window
    {
        public newfilewin()
        {
            InitializeComponent();
        }
        private void title_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Apply(object sender, RoutedEventArgs e)
        {
            Frame page2Frame = (Frame)Application.Current.MainWindow.FindName("frame");
            page2Frame.Navigate(new PageEdit());
            this.Close();
        }
        private void position_Click(object sender, RoutedEventArgs e)
        {



        }
    }
}
