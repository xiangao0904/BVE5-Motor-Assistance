using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.VisualTree;

namespace Avalonia_BVE5_Motor_Assistance.Controls
{
    public class CustomButton1 : RadioButton
    {
        public static readonly StyledProperty<int> RectangleWidthProperty =
            AvaloniaProperty.Register<CustomButton1, int>(nameof(RectangleWidth), defaultValue: 4);

        public int RectangleWidth
        {
            get => GetValue(RectangleWidthProperty);
            set => SetValue(RectangleWidthProperty, value);
        }

        public CustomButton1()
        {
            // 订阅 Loaded 事件
            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, EventArgs e)
        {
            if (this.GetVisualRoot() is not Window window) return;

            // 监听窗口大小变化
            window.SizeChanged += (s, args) =>
            {
                if (window.WindowState == WindowState.Maximized)
                {
                    RectangleWidth = 10; // 设定全屏时的宽度
                }
                else
                {
                    RectangleWidth = 4; // 设定正常状态下的宽度
                }
            };
        }
    }
}