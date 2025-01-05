using System.IO;
using System.Linq;

namespace Avalonia_BVE5_Motor_Assistance.ViewModels;

public class ReadCfg
{
    public string? GetSettingsKey(string key)
    {
        using var set = new StreamReader("Assets/settings.cfg");
        while (set.ReadLine() is { } line)
            if (line.StartsWith(key + "="))
                return line.Split('=').Last().Trim(); // 获取等号后的键值并去除空格  


        return null; // 如果没有找到对应键或发生错误，返回null
    }

    public void ModifySettingsValue(string key, string value)
    {
        const string filePath = "Assets/settings.cfg"; // 替换为你要修改的文件路径

        // 创建一个临时文件
        var tempFilePath = Path.GetTempFileName();
        using (var set = new StreamReader(filePath))
        using (var writer = new StreamWriter(tempFilePath))
        {
            while (set.ReadLine() is { } line)
                if (line.StartsWith(key))
                    writer.WriteLine(key + "=" + value);
                else
                    writer.WriteLine(line);
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