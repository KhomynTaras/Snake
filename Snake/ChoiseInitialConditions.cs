using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class ChoiseInitialConditions
    {
        public static void Choise(ref bool chekPlay, ref Snake snake)
        {
            while (true)
            {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.P)
                {
                    chekPlay = true;
                    HeaderText.ClearPrintMessage(7);
                    snake = new Snake(WindowSize.WindowWidth / 2, (WindowSize.WindowHeight + InitialParametrs.initialY) / 2, InitialParametrs.initialLenght);
                    break;
                }
                if (key.Key == ConsoleKey.I)
                {
                    var mass = ImportData.GetDataFromTxt();
                    if (mass != null)
                    {
                        snake = new Snake(mass);
                        HeaderText.PrintLastMessage("Файл завнатажено!");
                    }
                    else
                    {
                        snake = new Snake(WindowSize.WindowWidth / 2, (WindowSize.WindowHeight + InitialParametrs.initialY) / 2, InitialParametrs.initialLenght);
                        HeaderText.PrintLastMessage("Відсутні збережені дані! Завантажено автоматичні налаштування");
                    }
                    break;
                }
            }
        }
    }
}
