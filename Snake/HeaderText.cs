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
            PrintMessage("Оберіть рівень складності від 1 до 3: ",  1);
            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out Program.difficultyLevel) || Program.difficultyLevel < 1 || Program.difficultyLevel > 3)
                    Console.WriteLine("Введені дані мали невірний формат, спробуйте ще раз");
                else
                    break;
            }
            PrintMessage("Для початку гри натисніть клавішу \"P\"", 2);
            PrintMessage("Для паузи натисніть клавішу \"Space\"", 3);
            PrintMessage("Для збереження результатів натисніть клавішу \"S\"",  4);
            PrintMessage("Для завантаження результатів натисніть клавішу \"U\"", 5);

            Console.CursorVisible = false;

        }

        public static void PrintMessage(string message,int y)
        {
            Console.SetCursorPosition(WindowSize.WindowWidth / 2 - message.Length / 2, y);
            Console.Write(message);
        }
    }
}
