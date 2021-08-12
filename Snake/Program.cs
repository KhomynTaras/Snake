using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        public static Snake snake;
        static Walls walls;
        static FoodGeneration foodGeneration;
        static Timer time;

        static readonly int initialLenght = 4;
        public static double difficultyLevel = 1;
        public static bool chekPlay = false;
        //static bool gameOver = false;

        static void Main()
        {
            ExportData exportData = new ExportData();
            ImportData.GetMaxPoints();

            WindowSize.Value();

            walls = new Walls(WindowSize.WindowWidth, WindowSize.WindowHeight - 1, "#");
            HeaderText.Value();

            while (true)
            {
                if (Console.ReadKey(true).Key == ConsoleKey.P)
                {
                    chekPlay = true;
                    HeaderText.ClearPrintMessage(7);
                    snake = new Snake(WindowSize.WindowWidth / 2, (WindowSize.WindowHeight + Walls.initialY) / 2, initialLenght);
                    break;
                }
                if (Console.ReadKey(true).Key == ConsoleKey.I)
                {
                    var mass = ImportData.Data();
                    if (mass != null)
                    {
                        snake = new Snake(mass);
                        HeaderText.PrintLastMessage("Файл завнатажено!");
                    }
                    else
                    {
                        snake = new Snake(WindowSize.WindowWidth / 2, (WindowSize.WindowHeight + Walls.initialY) / 2, initialLenght);
                        HeaderText.PrintLastMessage("Відсутні збережені дані! Завантажено автоматичні налаштування");
                    }
                    break;
                }
            }

            foodGeneration = new FoodGeneration(WindowSize.WindowWidth, WindowSize.WindowHeight, "@");
            foodGeneration.CreateFood();

            time = new Timer(Loop, null, 0, (int)(200 / difficultyLevel));

            ConnectionWithPlayer connectionWithPlayer = new ConnectionWithPlayer(snake);
            while (true)
            {
                connectionWithPlayer.Connect();
            }
            //Console.ReadKey();
        }

        static void Loop(object obj)
        {
            if (chekPlay == true)
            {
                if (walls.IsHit(snake.GetHead()) || snake.IsHit(snake.GetHead()))
                {
                    //gameOver = true;
                    chekPlay = false;
                    HeaderText.PrintLastMessage("Game over!");
                    time.Change(0, Timeout.Infinite);
                }
                else if (snake.Eat(foodGeneration.food))
                {
                    foodGeneration.CreateFood();
                }
                else
                {
                    snake.Move();
                }
            }

        }
    }  
}
