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
        public void Connect(ref bool chekPlay, bool gameOver)
        {
            if (Console.KeyAvailable)
            {
                if(!gameOver)
                {
                    var key = Console.ReadKey(true);
                    snake.Rotation(key.Key);


                    if (key.Key == ConsoleKey.P)
                    {
                        chekPlay = true;
                        HeaderText.ClearPrintMessage(7);
                    }
                    if (key.Key == ConsoleKey.Spacebar)
                    {
                        chekPlay = false;
                        HeaderText.PrintLastMessage("Ви ввійшли в режим паузи!");
                    }
                    if (key.Key == ConsoleKey.S)
                    {
                        chekPlay = false;
                        ExportData.ExportSavedData();
                    }
                }
                else
                {
                    var key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.R)
                    {
                        ClearWindow.Clear();
                        PointsCounter.Reset();
  
                        Program.Main();
                    }
                }
            }
        }
    }
}
