using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class FoodGeneration
    {
        string ch;
        int x, y;
        public Point food { get; private set; }
        public static int GamePoints;
        public static int MaxGamePoints;

        Random random = new Random();

        public FoodGeneration(int x, int y, string ch)
        {
            this.x = x;
            this.y = y;
            this.ch = ch;
        }

        public void CreateFood()
        {
            int cX = 0; 
            int cY = 0;
            bool checkValue = false;

            while(!checkValue)
            {
                cX = random.Next(2, x - 2);
                cY = random.Next(Walls.initialY + 2, y - 2);

                for (int i = 0; i < Snake.snake.Count; i++)
                {
                    if (cX != Snake.snake[i].x && cY != Snake.snake[i].y)
                    {
                        checkValue = true; break;
                    }
                }
            }

            food = (cX, cY, ch);
            food.Draw();
        }

        public static void PointsCounter()
        {
            GamePoints++;
            if(MaxGamePoints < GamePoints)
            {
                MaxGamePoints = GamePoints;
                ExportData.ExportMaxPointsCount();
            }
            HeaderText.PrintPointsCounter();
        }
    }
}
