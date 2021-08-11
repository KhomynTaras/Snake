﻿using System;
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

        Random random = new Random();

        public FoodGeneration(int x, int y, string ch)
        {
            this.x = x;
            this.y = y;
            this.ch = ch;
        }

        public void CreateFood()
        {
            food = (random.Next(2, x - 2), random.Next(Walls.initialY + 2, y - 2), ch);
            food.Draw();
        }
    }
}
