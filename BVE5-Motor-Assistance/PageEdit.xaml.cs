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

namespace BVE5_Motor_Assistance
{
    /// <summary>
    /// PageEdit.xaml 的交互逻辑
    /// </summary>
    public partial class PageEdit : Page, INotifyPropertyChanged
    {
        public PageEdit()
        {
            InitializeComponent();
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


    }
}
