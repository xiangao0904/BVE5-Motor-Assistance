using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Avalonia_BVE5_Motor_Assistance.Views;

public partial class EditWindow : Window
{
    public EditWindow(string soundName,int maxSpeed)
    {
        InitializeComponent();
        WindowState = WindowState.Maximized;
        SoundName.Text = soundName;
    }
}