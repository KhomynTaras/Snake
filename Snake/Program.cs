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
        static string gameState;

        static void Main()
        { 
            WindowSize.Value();

            walls = new Walls(WindowSize.WindowWidth, WindowSize.WindowHeight - 1, "#");
            snake = new Snake(WindowSize.WindowWidth / 2, WindowSize.WindowHeight / 2 + Walls.initialY, 4);

            foodGeneration = new FoodGeneration(WindowSize.WindowWidth, WindowSize.WindowHeight, "@");
            foodGeneration.CreateFood();

            HeaderText.Value();

            Console.CursorVisible = false;

            time = new Timer(Loop, null, 0, 200 / difficultyLevel);
          
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.Rotation(key.Key);
                }
            }
        }

        static void Loop(object obj)
        {
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.P)
                chekPlay = true;
            if (key.Key == ConsoleKey.S || key.Key == ConsoleKey.Spacebar)
                chekPlay = false;

            if(chekPlay == true)
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
