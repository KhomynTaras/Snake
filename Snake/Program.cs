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

        static void Main()
        {
            WindowSize.Value();

            walls = new Walls(WindowSize.WindowWidth, WindowSize.WindowHeight, '#');
            snake = new Snake(WindowSize.WindowWidth / 2, WindowSize.WindowHeight / 2, 4);

            foodGeneration = new FoodGeneration(WindowSize.WindowWidth, WindowSize.WindowHeight, '@');
            foodGeneration.CreateFood();

            time = new Timer(Loop, null, 0, 200);

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.Rotation(key.Key);
                }
            }

            Console.ReadLine();
        }

        static void Loop(object obj)
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
