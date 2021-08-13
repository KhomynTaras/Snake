using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class HeaderText
    {
        public static void Value()
        {
            Console.OutputEncoding = Encoding.UTF8;

            PrintMessage("SNAKE", 0);
            PrintPointsCounter();

            string message = "Оберіть рівень складності від 1 до 3: ";
            PrintMessage(message,  2);
            VerificationDifficultyLevelValue(message);

            PrintMessage("Для початку гри натисніть клавішу \"P\"", 3);
            PrintMessage("Для паузи натисніть клавішу \"Space\"", 4);
            PrintMessage("Для збереження результатів натисніть клавішу \"S\"",  5);
            PrintMessage("Для завантаження результатів натисніть клавішу \"I\"", 6);

            Console.CursorVisible = false;
        }

        public static void PrintMessage(string message,int y)
        {
            Console.SetCursorPosition(WindowSize.WindowWidth / 2 - message.Length / 2, y);
            Console.Write(message);
        }
        public static void ClearPrintMessage(int y)
        {
            string message = "                                                                                 ";
            Console.SetCursorPosition(WindowSize.WindowWidth / 2 - message.Length / 2, y);
            Console.Write(message);
        }

        public static void PrintPointsCounter()
        {
            PrintMessage($"GamePoints: {PointsCounter.GamePoints}, MaxGamePoints: {PointsCounter.MaxGamePoints}", 1);
        }
        public static void PrintLastMessage(string message)
        {
            ClearPrintMessage(7);
            PrintMessage(message, 7);
        }
        private static void VerificationDifficultyLevelValue(string message)
        {
            while (true)
            {
                ClearPrintMessage(2);
                PrintMessage(message, 2);

                if (!int.TryParse(Console.ReadLine(), out InitialParametrs.difficultyLevel) || InitialParametrs.difficultyLevel < 1 || InitialParametrs.difficultyLevel > 3)
                    PrintLastMessage("Введені дані мали невірний формат, спробуйте ще раз");
                else
                {
                    ClearPrintMessage(7);
                    break;
                }

            }
        }
    }
}
