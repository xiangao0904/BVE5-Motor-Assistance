using BVE5_Motor_Assistance.Logic;
using Microsoft.Win32;
using System.IO;
using System.Text.RegularExpressions;
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
            if (maxspeed.Text != "" &&  name.Text !="")
            {
                int maxSpeed = Convert.ToInt32(maxspeed.Text);
                if (maxSpeed > 400)
                {
                    MessageBox.Show("最大值不超过400", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                }else if (maxSpeed % 10 != 0)
                {
                    MessageBox.Show("请输入10的倍数", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    Frame page2Frame = (Frame)Application.Current.MainWindow.FindName("frame");
                    page2Frame.Navigate(new PageEdit());
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("请正确输入速度值或名称", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void position_Click(object sender, RoutedEventArgs e)
        {



        }

        private void maxspeed_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex re = new Regex("[^0-9]+");
            e.Handled = re.IsMatch(e.Text);
        }
    }
}
