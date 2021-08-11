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
        static Snake snake;
        static Walls walls;
        static FoodGeneration foodGeneration;
        static Timer time;
        public static int difficultyLevel = 1;
        static bool chekPlay = false;

        static void Main()
        { 
            WindowSize.Value();

            walls = new Walls(WindowSize.WindowWidth, WindowSize.WindowHeight - 1, "#");
            snake = new Snake(WindowSize.WindowWidth / 2, WindowSize.WindowHeight / 2 + Walls.initialY, 4);

            foodGeneration = new FoodGeneration(WindowSize.WindowWidth, WindowSize.WindowHeight, "@");
            foodGeneration.CreateFood();

            HeaderText.Value();

            time = new Timer(Loop, null, 0, 200 / difficultyLevel);

            while (true)
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
                        chekPlay = true;
                    if (key.Key == ConsoleKey.Spacebar)
                        chekPlay = false;
                    if (key.Key == ConsoleKey.S)
                    {
                        chekPlay = false;
                        ExportData expD = new ExportData();
                        expD.Export();
                    }

                }
            }
        }

        static void Loop(object obj)
        {
            if (chekPlay == true)
            {
                if (walls.IsHit(snake.GetHead()) || snake.IsHit(snake.GetHead()))
                {
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
