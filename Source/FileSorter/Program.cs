using System;
using System.Threading;
using System.IO;

namespace FileSorter
{
    class Program
    {
        static public void fileMover()
        {
            if(Environment.HasShutdownStarted)
            {
                Environment.Exit(0);
            }
            string path = @"C:\Users\" + Environment.UserName + @"\Downloads";
            if (Directory.Exists(path))
            {
                string[] files = Directory.GetFiles(path);
                for (int i = 0; i < files.Length; i++)
                {
                    string extesion = files[i].Split('.')[files[i].Split('.').Length - 1];
                    string folderPath = path + @"\" + extesion;

                    Directory.CreateDirectory(folderPath);
                    File.Move(files[i], path + @"\" + extesion + @"\" + files[i].Split(Convert.ToChar(@"\"))[files[i].Split(Convert.ToChar(@"\")).Length - 1]);
                }
            }
            else
            {
                Console.WriteLine("404 dir not found");
                throw new NullReferenceException("404 dir not found");
            }
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Thread.Sleep(1000);
                fileMover();
            }
        }
    }
}
