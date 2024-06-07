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

namespace BVE5_Motor_Assistance
{
    /// <summary>
    /// PageEdit.xaml 的交互逻辑
    /// </summary>
    public partial class PageEdit : Page
    {
        public PageEdit()
        {
            InitializeComponent();
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
                
                soundfilebutton.Content = openFileDialog.SafeFileName;
                readCfgInstance.ModifySettingsValue("lastDirectory", System.IO.Path.GetDirectoryName(openFileDialog.FileName));
            }
        }
    }
}
