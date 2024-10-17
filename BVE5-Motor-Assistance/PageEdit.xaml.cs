using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
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


using BVE5_Motor_Assistance.Logic;
using System.ComponentModel;
using System.Windows.Threading;

namespace BVE5_Motor_Assistance
{
    /// <summary>
    /// PageEdit.xaml 的交互逻辑
    /// </summary>
    public partial class PageEdit : Page, INotifyPropertyChanged
    {
        private int maxSpeed;
        public PageEdit(int maxSpeed,string name)
        {
            InitializeComponent();
            this.maxSpeed = maxSpeed;
            speed.Text = maxSpeed.ToString();
            NameText.Text = name;
            // 添加 Loaded 事件处理程序
            this.SizeChanged += PageEdit_SizeChanged;

        }

        private void PageEdit_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            RenderContext();
            RenderLines(maxSpeed);
        }

       

        private string _fileName;

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string FileName
        {
            get { return _fileName; }
            set
            {
                if (_fileName != null)
                {
                    _fileName = value;
                    OnPropertyChanged("FileName");
                }

            }
        }

        private void SoundFile_Click(object sender, RoutedEventArgs e)
        {

            ReadCFG readCfgInstance = new ReadCFG();
            string lastDirectory = readCfgInstance.GetSettingsKey("lastDirectory");


            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (Directory.Exists(lastDirectory))
            {
                openFileDialog.InitialDirectory = lastDirectory;
            }
            else
            {
                openFileDialog.InitialDirectory = Directory.GetCurrentDirectory(); // 默认目录
            }
            openFileDialog.Filter = "motorsounds|*.wav;*.ogg;";
            if (openFileDialog.ShowDialog() == true)
            {
                string fileName = openFileDialog.SafeFileName.Trim();
                string fileName2 = fileName.Substring(0, fileName.Length - 4);
                FileName = fileName;
                NameText.Text = fileName2;
                soundfilebutton.Content = fileName;
                readCfgInstance.ModifySettingsValue("lastDirectory", System.IO.Path.GetDirectoryName(openFileDialog.FileName));
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }



        private void LayerColor_Enter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                FocusManager.SetFocusedElement(this, null);
            }
        }



        private void LayerColor_lostF(object sender, KeyboardFocusChangedEventArgs e)
        {
            string text = LayerColor.Text;
            try
            {
                if (text != "")
                {
                    LayerColor.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#" + text));
                }
                else
                {

                    LayerColor.Foreground = new SolidColorBrush(Colors.White);
                }
            }
            catch (Exception)
            {
                LayerColor.Text = "";
                MessageBox.Show("请输入正确的16进制颜色值", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
        private void RenderContext()
        {
            var nonLineChildren = EditSpace.Children.OfType<UIElement>().Where(child => !(child is TextBlock)).ToList();

            // 清除所有子元素
            EditSpace.Children.Clear();

            // 重新添加非线条组件
            foreach (var child in nonLineChildren)
            {
                EditSpace.Children.Add(child);
            }
            int renderCount = maxSpeed / 10;
            double canvasWidth = EditSpace.ActualWidth - (52 * 2);
            double lineSpacing = canvasWidth / renderCount;

            AddTextBlock("音高", 8);
            AddTextBlock("音量", EditSpace.ActualHeight - 255);

        }
        private void AddTextBlock(string text, double top)
        {
            TextBlock textBlock = new TextBlock()
            {
                Text = text,
                FontFamily = (FontFamily)FindResource("Deyihei"),
                Foreground = Brushes.White,
                FontSize = 15
            };
            Canvas.SetLeft(textBlock, 16);
            Canvas.SetTop(textBlock, top);
            EditSpace.Children.Add(textBlock);
        }
        private void RenderLines(int maxSpeed)
        {
            var nonLineChildren = EditSpace.Children.OfType<UIElement>().Where(child => !(child is Line)).ToList();

            // 清除所有子元素
            EditSpace.Children.Clear();

            // 重新添加非线条组件
            foreach (var child in nonLineChildren)
            {
                EditSpace.Children.Add(child);
            }

            int renderCount = maxSpeed / 10;
            double canvasWidth = EditSpace.ActualWidth - (52 * 2);
            double lineSpacing = canvasWidth / renderCount;

            // 绘制竖线
            DrawVerticalLines(renderCount, lineSpacing, 32, EditSpace.ActualHeight - 290);
            DrawVerticalLines(renderCount, lineSpacing, EditSpace.ActualHeight - 230, EditSpace.ActualHeight - 32);

            // 绘制横线
            lineSpacing = (EditSpace.ActualHeight - 304 - 42) / 9;
            DrawHorizontalLines(9, lineSpacing, 42, EditSpace.ActualWidth - 42, 41);

            lineSpacing = (190 - 13) / 4;
            DrawHorizontalLines(4, lineSpacing, 42, EditSpace.ActualWidth - 42, EditSpace.ActualHeight - 220);

        }

        private void DrawVerticalLines(int count, double lineSpacing, double startY, double endY)
        {
            for (int i = 0; i <= count; i++)
            {
                Line line = new Line()
                {
                    X1 = 52 + i * lineSpacing,
                    Y1 = startY,
                    X2 = 52 + i * lineSpacing,
                    Y2 = endY,
                    Stroke = Brushes.White,
                    StrokeThickness = 2.5
                };

                EditSpace.Children.Add(line);
            }
        }

        private void DrawHorizontalLines(int count, double lineSpacing, double startX, double endX, double startY)
        {
            for (int i = 0; i <= count; i++)
            {
                Line line = new Line()
                {
                    X1 = startX,
                    Y1 = startY + i * lineSpacing,
                    X2 = endX,
                    Y2 = startY + i * lineSpacing,
                    Stroke = Brushes.White,
                    StrokeThickness = 2
                };

                EditSpace.Children.Add(line);
            }
        }
    }
}
