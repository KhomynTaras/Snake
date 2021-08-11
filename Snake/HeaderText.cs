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

            string mess0 = "SNAKE";
            Point p0 = (WindowSize.WindowWidth / 2 - mess0.Length / 2, 0, mess0);
            p0.Draw();
            string mess1 = "Оберіть рівень складності від 1 до 3: ";
            Point p1 = (WindowSize.WindowWidth / 2 - mess1.Length / 2, 1, mess1);
            p1.Draw();

            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out Program.difficultyLevel) || Program.difficultyLevel < 1 || Program.difficultyLevel > 3)
                    Console.WriteLine("Введені дані мали невірний формат, спробуйте ще раз");
                else
                    break;
            }

            string mess2 = "Для початку гри нажміть клавішу \"P\"";
            Point p2 = (WindowSize.WindowWidth / 2 - mess2.Length / 2, 2, mess2);
            p2.Draw();

            string mess3 = "Для паузи нажміть клавішу \"Space\"";
            Point p3 = (WindowSize.WindowWidth / 2 - mess3.Length / 2, 3, mess3);
            p3.Draw();

            string mess4 = "Для збереження результатів нажміть клавішу \"S\"";
            Point p4 = (WindowSize.WindowWidth / 2 - mess4.Length / 2, 4, mess4);
            p4.Draw();
        }

        //static void PrintMessage(string message)
        //{
        //    Point p = (WindowSize.WindowWidth / 2 - message.Length / 2, 0, message);
        //    p.Draw();
        //}
    }
}
