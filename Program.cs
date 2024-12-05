using System;
using System.Collections.Generic;
using System.IO;

class Program
{


    static void Main()
    {
        var Path = Console.ReadLine();

        List<string> allFiles = GetAllFiles(Path);

        foreach (string file in allFiles)
        {
            Console.WriteLine(file);
        }


    }

    static List<string> GetAllFiles(string directory)
    {
        List<string> files = new List<string>();

        try
        {
            // Получаем все файлы в текущей директории
            files.AddRange(Directory.GetFiles(directory));

            // Рекурсивно обходим все подкаталоги
            foreach (string subDirectory in Directory.GetDirectories(directory))
            {
                files.AddRange(GetAllFiles(subDirectory));
            }
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine($"Нет доступа к папке: {directory}. Ошибка: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при работе с папкой: {directory}. Ошибка: {ex.Message}");
        }

        return files;
    }


}