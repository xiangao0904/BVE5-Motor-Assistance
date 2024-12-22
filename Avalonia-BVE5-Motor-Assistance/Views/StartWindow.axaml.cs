using Avalonia.Controls;
using Avalonia.Input;

namespace Avalonia_BVE5_Motor_Assistance.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.PointerPressed += MainWindow_PointerPressed;
        }

        private void MainWindow_PointerPressed(object? sender, Avalonia.Input.PointerPressedEventArgs e)
        {
            if (e.Pointer.Type == PointerType.Mouse)
            {
                this.BeginMoveDrag(e);
            }
        }

     
    }
}