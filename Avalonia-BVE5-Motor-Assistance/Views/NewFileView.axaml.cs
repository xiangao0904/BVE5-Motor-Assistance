using System;
using System.Text.RegularExpressions;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;

namespace Avalonia_BVE5_Motor_Assistance.Views;

public partial class NewFileView : UserControl
{
    public NewFileView()
    {
        InitializeComponent();
    }

    private void InputElement_OnLostFocus(object? sender, RoutedEventArgs e)
    {
        // 确保发送者是 NumericUpDown
        if (sender is NumericUpDown numericUpDown)
        {
            // 获取当前数值
            var value = numericUpDown.Value;

            if (value.HasValue)
            {
                try
                {
                    // 尝试将当前值转换为 int
                    double doubleValue = Convert.ToDouble(value.Value);

                    // 如果转换成功，检查是否可以被 10 整除
                    if (doubleValue % 10 != 0)
                    {
                        doubleValue = Math.Round(doubleValue / 10.0) * 10.0;
                        numericUpDown.Value = (decimal?)doubleValue;
                    }
                }
                catch (OverflowException)
                {
                    // 值超出 int 范围
                    Console.WriteLine($"{value.Value} 超出 int 的范围，无法转换为 int。");
                }
                catch (Exception ex)
                {
                    // 处理其他潜在异常
                    Console.WriteLine($"转换出错: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("没有输入有效的值。");
            }
        
        }
    }


}