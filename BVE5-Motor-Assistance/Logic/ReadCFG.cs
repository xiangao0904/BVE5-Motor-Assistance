using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace BVE5_Motor_Assistance.Logic
{
    public class ReadCFG
    {
        public string GetSettingsKey(string key)
        {

            using (StreamReader set = new StreamReader("./ProgramFile/settings.cfg"))
            {
                string line;
                while ((line = set.ReadLine()) != null)
                {
                    if (line.StartsWith(key + "="))
                    {
                        return line.Split('=').Last().Trim(); // 获取等号后的键值并去除空格  
                    }
                }
            }



            return null; // 如果没有找到对应键或发生错误，返回null
        }

        public void ModifySettingsValue(string key, string value)
        {
            string filePath = "./ProgramFile/settings.cfg"; // 替换为你要修改的文件路径

            // 创建一个临时文件
            string tempFilePath = System.IO.Path.GetTempFileName();
            using (StreamReader set = new StreamReader(filePath))
            using (StreamWriter writer = new StreamWriter(tempFilePath))
            {
                string line;
                while ((line = set.ReadLine()) != null)
                {
                    if (line.StartsWith(key))
                    {
                        writer.WriteLine(key + "=" + value);
                    }
                    else
                    {
                        writer.WriteLine(line);
                    }
                }
            }



            // 用修改后的内容覆盖原文件
            File.Delete(filePath);
            File.Move(tempFilePath, filePath);



            //catch (Exception ex)
            //{
            //    Console.WriteLine("修改文件时发生错误： " + ex.Message);
            //}

        }
    }
}

