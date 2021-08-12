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
        public ExportData()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(pathFolder);
            if (!dirInfo.Exists)
                dirInfo.Create();
        }

        public static readonly string pathFolder = $@"{Directory.GetCurrentDirectory()}\SavedData";
        public static readonly string pathTxtFileSavedData = $@"{pathFolder}\SavedData.txt";
        public static readonly string pathTxtFileMaxPointsCount = $@"{pathFolder}\MaxPointsCount.txt";

        public static void ExportSavedData()
        {
            StreamWriter print = new StreamWriter(pathTxtFileSavedData, false);
            print.Write(FoodGeneration.GamePoints);
            print.WriteLine();
            for (int i = 0; i < Snake.snake.Count; i++)
            {
                print.Write(Snake.snake[i].x + " ");
                print.Write(Snake.snake[i].y);
                print.WriteLine();
            }
            print.Close();
            HeaderText.PrintLastMessage("Файл збережено!");
        }

        public static void ExportMaxPointsCount()
        {
            File.WriteAllText(pathTxtFileMaxPointsCount, $"{FoodGeneration.GamePoints}");
        }
    }
}
