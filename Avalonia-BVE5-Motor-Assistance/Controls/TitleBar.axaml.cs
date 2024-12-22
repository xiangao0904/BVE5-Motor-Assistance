using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Avalonia_BVE5_Motor_Assistance.Controls;

public partial class TitleBar : UserControl
{
    public TitleBar()
    {
        InitializeComponent();
    }
    private void Close_Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (this.VisualRoot is Window window)
        {
            window.Close();
        }
         
    }

private void Max_Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
{
    // 获取当前 UserControl 的所属窗口，并确保不为 null
    if (this.VisualRoot is Window window)
    {
        window.WindowState = window.WindowState == WindowState.Normal 
            ? WindowState.Maximized 
            : WindowState.Normal; // 切换状态
    }
}

    private void Min_Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {

        if (this.VisualRoot is Window window)
        {
            window.WindowState = WindowState.Minimized;
        }
        
    }
}