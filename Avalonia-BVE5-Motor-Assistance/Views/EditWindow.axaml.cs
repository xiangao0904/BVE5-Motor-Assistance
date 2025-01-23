using System;
using System.IO;
using System.Linq;
using Avalonia_BVE5_Motor_Assistance.ViewModels;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.Platform.Storage;

namespace Avalonia_BVE5_Motor_Assistance.Views;

public partial class EditWindow : Window
{
    private int maxSpeed;

    // 无参的公共构造函数，用于 XAML 加载器
    private EditWindow()
    {
        InitializeComponent();
        this.SizeChanged += OnWindowSizeChanged;
        PointerPressed += MainWindow_PointerPressed;
    }

    // 带参数的构造函数，用于业务逻辑
    public EditWindow(string soundName, int maxSpeed) : this() // 调用无参构造函数
    {
        WindowState = WindowState.Maximized;
        SoundName.Text = soundName;
        // 可以在这里添加更多逻辑
        this.maxSpeed = maxSpeed;
        // speed.Text = maxSpeed.ToString();
        // 添加 Loaded 事件处理程序
        // RenderContext();
        // RenderLines(maxSpeed);
    }

    private void MainWindow_PointerPressed(object? sender, PointerPressedEventArgs e)
    {
        if (e.Pointer.Type == PointerType.Mouse) BeginMoveDrag(e);
    }

    private void RenderContext()
    {
        double canvasWidth = EditSpace.Bounds.Width - (52 * 2); // 减去两侧的边距
        double canvasHeight = EditSpace.Bounds.Height;

        var nonLineChildren = EditSpace.Children.OfType<Control>().Where(child => !(child is TextBlock)).ToList();

        EditSpace.Children.Clear();

        foreach (var child in nonLineChildren)
        {
            EditSpace.Children.Add(child);
        }

        // 计算线条数量和间距
        int renderCount = maxSpeed / 10;
        double lineSpacing = canvasWidth / renderCount;
        // 添加文本块
        AddTextBlock("音高", 8);
        AddTextBlock("音量", canvasHeight * 0.6790);
    }

    private void AddTextBlock(string text, double top)
    {
        var fontFamily = (FontFamily)Application.Current?.Resources["DeYi"]!;
        TextBlock textBlock = new TextBlock()
        {
            Text = text,
            FontFamily = fontFamily,
            Foreground = Brushes.White,
            FontSize = 15
        };
        Canvas.SetLeft(textBlock, 16);
        Canvas.SetTop(textBlock, top);
        EditSpace.Children.Add(textBlock);
    }

    private void RenderLines(int theMaxSpeed)
    {
        // 获取非 Line 的子元素
        var nonLineChildren = EditSpace.Children.OfType<Control>().Where(child => !(child is Line)).ToList();

        // 清除所有子元素
        EditSpace.Children.Clear();

        // 重新添加非线条组件
        foreach (var child in nonLineChildren)
        {
            EditSpace.Children.Add(child);
        }

        // 计算线条数量和间距
        double canvasWidth = EditSpace.Bounds.Width - (52 * 2); // 使用 Bounds.Width 获取实际宽度

        // 绘制竖线
        DrawVerticalLines(theMaxSpeed / 10, 32, EditSpace.Bounds.Height * (0.62));
        DrawHorizontalLines(9, 42, EditSpace.Bounds.Width - 42, 41, EditSpace.Bounds.Height * (0.62) - 10);

        DrawVerticalLines(theMaxSpeed / 10, EditSpace.Bounds.Height * (0.7001), EditSpace.Bounds.Height - 41);
        DrawHorizontalLines(4, 42, EditSpace.Bounds.Width - 42, EditSpace.Bounds.Height * (0.7001) + 10,
            EditSpace.Bounds.Height - 41 - 10);
        // DrawVerticalLines(renderCount, lineSpacing, EditSpace.Bounds.Height - 230, EditSpace.Bounds.Height - 32);
        //
        // // 绘制横线
        //
        // lineSpacing = (190 - 13) / 4;
        // DrawHorizontalLines(4, lineSpacing, 42, EditSpace.Bounds.Width - 42, EditSpace.Bounds.Height - 220);
    }

    private void DrawVerticalLines(int count, double startY, double endY)
    {
        double lineSpacing = (EditSpace.Bounds.Width - (52 * 2)) / count;
        for (int i = 0; i <= count; i++)
        {
            var line = new Line
            {
                StartPoint = new Point(52 + i * lineSpacing, startY),
                EndPoint = new Point(52 + i * lineSpacing, endY),
                Stroke = new SolidColorBrush(Colors.White),
                StrokeThickness = 2.5
            };

            EditSpace.Children.Add(line);
        }
    }

    private void DrawHorizontalLines(int count, double startX, double endX, double startY, double endY)
    {
        double lineSpacing = (endY - startY) / count;
        for (int i = 0; i <= count; i++)
        {
            var line = new Line
            {
                StartPoint = new Point(startX, startY + i * lineSpacing),
                EndPoint = new Point(endX, startY + i * lineSpacing),
                Stroke = new SolidColorBrush(Colors.White),
                StrokeThickness = 2
            };

            EditSpace.Children.Add(line);
        }
    }

    private void OnWindowSizeChanged(object sender, SizeChangedEventArgs e)
    {
        RenderContext();
        RenderLines(maxSpeed);
    }

    private static FilePickerFileType soundFileType { get; } = new("sound file")
    {
        Patterns = new[] { "*.wav", "*.ogg" },
        AppleUniformTypeIdentifiers = new[] { "public.wav" },
        MimeTypes = new[] { "sound/wav", "sound/ogg" },
    };

    private async void Button_ReadFile(object? sender, RoutedEventArgs e)
    {
        ReadCfg readCfg = new ReadCfg();
        string? lastDirectory = readCfg.GetSettingsKey("lastDirectory");

        var topLevel = TopLevel.GetTopLevel(this);

        // 如果有上次的目录路径，尝试将其转换为 IStorageFolder
        IStorageFolder? suggestedStartLocation = null;
        if (!string.IsNullOrEmpty(lastDirectory))
        {
            suggestedStartLocation = await topLevel.StorageProvider.TryGetFolderFromPathAsync(lastDirectory);
        }

        // 启动异步操作以打开对话框。
        var files = await topLevel.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
        {
            Title = "Open Text File",
            AllowMultiple = false,
            FileTypeFilter = new[] { soundFileType },
            SuggestedStartLocation = suggestedStartLocation // 设置初始目录为上次选择的目录
        });

        if (files.Count >= 1)
        {
            // 打开第一个文件的读取流。
            await using var stream = await files[0].OpenReadAsync();
            using var streamReader = new StreamReader(stream);
            var fileContent = await streamReader.ReadToEndAsync();
            // // 获取文件的父目录路径s
            string? parentFolderPath = System.IO.Path.GetDirectoryName(files[0].Path.ToString().Remove(0, 8));
            // Console.WriteLine(parentFolderPath);
            // 保存新的目录路径到配置中
            if (parentFolderPath != null)
            {
                readCfg.ModifySettingsValue("lastDirectory", parentFolderPath);
            }
        }
    }
}