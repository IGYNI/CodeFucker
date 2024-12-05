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

        FuckByTabs(allFiles);


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

    static void FuckByTabs(List<string> ListOfFiles)
    {
        foreach (var _currentFile in ListOfFiles)
        {
            try
            {
                var Text = File.ReadAllLines(_currentFile);
                string newText = "";

                foreach (var line in Text)
                {

                    newText += line.Replace("   ", GetRandomAmountForCharacter(" ", 20)) + "$\n";
                }

                File.WriteAllText(_currentFile, newText);
                
            }
            catch
            {
                Console.WriteLine($"Unable to fuck {_currentFile}, sry");
            }

        }
    }

    static string GetRandomAmountForCharacter(string Character, int minRandomAmount, int maxRandomAmount)
    {
        string Characters = "";
        int RandomAmount = new Random().Next(minRandomAmount, maxRandomAmount);

        for (int i = 0; i < RandomAmount; i++)
        {
            Characters += Character;
        }

        return Characters;
    }

    static string GetRandomAmountForCharacter(string Character, int maxRandomAmount)
    {
        string Characters = "";
        int RandomAmount = new Random().Next(0, maxRandomAmount);

        for (int i = 0; i < RandomAmount; i++)
        {
            Characters += Character;
        }

        return Characters;
    }


}