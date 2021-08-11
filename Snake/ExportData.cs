using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class ExportData
    {
        public static readonly string pathFolder = $@"{Directory.GetCurrentDirectory()}\SavedData";
        public static readonly string pathTxtFile = $@"{pathFolder}\SavedData.txt";

        public void Export()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(pathFolder);
            if (!dirInfo.Exists)
                dirInfo.Create();

            StreamWriter print = new StreamWriter(pathTxtFile, false);
            for (int i = 0; i < Snake.snake.Count; i++)
            {
                print.Write(Snake.snake[i].x + " ");
                print.Write(Snake.snake[i].y + " ");
                print.WriteLine();

            }
            print.Close();

            HeaderText.PrintMessage("Файл збережено! Для продовження натисніть клавішу \"P\"", 5);

            //File.AppendAllText(pathTxtFile, $"{text}\n");
            //File.WriteAllText(pathTxtFile, $"{text}\n");
        }
    }
}
