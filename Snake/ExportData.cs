using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class ExportData : Path
    {     
        public static void ExportSavedData()
        {
            StreamWriter print = new StreamWriter(pathTxtFileSavedData, false);
            print.Write(PointsCounter.GamePoints);
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
            File.WriteAllText(pathTxtFileMaxPointsCount, $"{PointsCounter.GamePoints}");
        }
    }
}
