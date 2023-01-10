using System;
using System.IO;

namespace Task8Subtask1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ввидите адрес удаляемой папки");
            string DirDirectory = Console.ReadLine();
            if (Directory.Exists(DirDirectory))
            {
                var di = new DirectoryInfo(DirDirectory);
                foreach (FileInfo file in di.GetFiles())
                {
                    if ((DateTime.Now - file.LastAccessTime) > TimeSpan.FromMinutes(30))

                    {
                        file.Delete();
                        Console.WriteLine("Файл {0} удален ", file.Name);
                    }

                }
                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    if ((DateTime.Now - dir.LastAccessTime) > TimeSpan.FromMinutes(30))
                    {
                        dir.Delete(true);
                        Console.WriteLine("Папка {0} удалена", dir.Name);
                    }
                }
            }
            else
            {
                Console.WriteLine("Папка не найдена. \n Введите корректный адрес папки");
            }

        }
    }
}

