using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BVE5_Motor_Assistance
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            frame.Navigate(new PageStart());
            this.Loaded += this.Window_Loaded;
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void ButtonMax_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
            }
            else
            {
                this.WindowState = WindowState.Maximized;
            }
        }
        private void ButtonMin_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void title_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            OnStateChanged(null);
        }
        protected override void OnStateChanged(EventArgs e)
        {
            switch (this.WindowState)
            {
                case WindowState.Maximized:
                    this.MaxWidth = SystemParameters.WorkArea.Width + 16;
                    this.MaxHeight = SystemParameters.WorkArea.Height + 16;
                    this.BorderThickness = new Thickness(5); //最大化后需要调整
                    //this.MinHeight = 512;
                    //this.MinWidth = 720;
                    break;

                case WindowState.Normal:
                    this.BorderThickness = new Thickness(0);
                    this.MaxWidth = SystemParameters.WorkArea.Width + 16;
                    this.MaxHeight = SystemParameters.WorkArea.Height + 16;
                    //this.MinHeight = 512;
                    //this.MinWidth = 720;
                    break;
            }



        }

        private void Thumb_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {



            double yAdjust = Height + e.VerticalChange;
            double xAdjust = Width + e.HorizontalChange;

            //make sure not to resize to negative width or heigth            
            xAdjust = (ActualWidth + xAdjust) > MinWidth ? xAdjust : MinWidth;
            yAdjust = (ActualHeight + yAdjust) > MinHeight ? yAdjust : MinHeight;

            Width = xAdjust;
            Height = yAdjust;
        }


    }
}