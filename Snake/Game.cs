using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    class Game
    {
        Timer time;
        Walls walls;
        Snake snake;
        FoodGeneration foodGeneration;

        bool chekPlay = false;
        bool gameOver = false;

        public void Play()
        {
            ImportData.GetMaxPoints();

            walls = new Walls(CheckWindowSize.WindowWidth, CheckWindowSize.WindowHeight - 1, "#");

            HeaderText.Value();

            ChoiseInitialConditions.Choise(ref chekPlay, ref snake);

            foodGeneration = new FoodGeneration(CheckWindowSize.WindowWidth, CheckWindowSize.WindowHeight, "@");
            foodGeneration.CreateFood();

            time = new Timer(Loop, null, 0, 200 / InitialParametrs.difficultyLevel);

            ConnectionWithPlayer connectionWithPlayer = new ConnectionWithPlayer(snake);
            while (true)
            {
                connectionWithPlayer.Connect(ref chekPlay, gameOver);
            }
        }

        void Loop(object obj)
        {
            if (chekPlay == true)
            {
                if (walls.IsHit(snake.GetHead()) || snake.IsHit(snake.GetHead()))
                {
                    gameOver = true;
                    chekPlay = false;
                    HeaderText.PrintLastMessage("Game over!, для рестарту натисніть клавішу R");
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
