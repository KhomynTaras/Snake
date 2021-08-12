using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class ConnectionWithPlayer
    {
        Snake snake;
        public ConnectionWithPlayer(Snake snake)
        {
            this.snake = snake;
        }
        public void Connect()
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.UpArrow)
                    snake.Rotation("U");
                if (key.Key == ConsoleKey.DownArrow)
                    snake.Rotation("D");
                if (key.Key == ConsoleKey.LeftArrow)
                    snake.Rotation("L");
                if (key.Key == ConsoleKey.RightArrow)
                    snake.Rotation("R");
                if (key.Key == ConsoleKey.P)
                {
                    Program.chekPlay = true;
                    HeaderText.ClearPrintMessage(7);
                }
                if (key.Key == ConsoleKey.Spacebar)
                {
                    Program.chekPlay = false;
                    HeaderText.PrintLastMessage("Ви ввійшли в режим паузи!");
                }
                if (key.Key == ConsoleKey.S)
                {
                    ExportData.ExportSavedData();
                    Program.chekPlay = false;
                }
            }
        }
    }
}
