using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class ImportData
    {
        public static int[,] Data()
        {
            string pathFile = ExportData.pathTxtFileSavedData;
            if (File.Exists(pathFile))
            {
                string[] lines = File.ReadAllLines(pathFile);

                if (lines.Length != 0)
                {
                    FoodGeneration.GamePoints = Convert.ToInt32(lines[0]);
                    HeaderText.PrintPointsCounter();

                    int[,] num = new int[lines.Length - 1, lines[1].Split(' ').Length];

                    for (int i = 0; i <= num.GetUpperBound(0); i++)
                    {
                        string[] temp = lines[i + 1].Split(' ');
                        for (int j = 0; j < temp.Length; j++)
                            num[i, j] = Convert.ToInt32(temp[j]);
                    }
                    return num;
                }
                return null;
            }
            return null;
        }

        public static void GetMaxPoints()
        {
            if (File.Exists(ExportData.pathTxtFileMaxPointsCount))
                FoodGeneration.MaxGamePoints = Convert.ToInt32(File.ReadAllText(ExportData.pathTxtFileMaxPointsCount));
        }
    }
}
