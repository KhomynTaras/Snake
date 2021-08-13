using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Walls
    {
        private string ch;

        private List<Point> wall = new List<Point>();

        public Walls(int x, int y, string ch)
        {
            this.ch = ch;
            DrawHorizontal(x, InitialParametrs.initialY);
            DrawHorizontal(x, y);
            DrawVertical(0, y);
            DrawVertical(x - 1, y);
        }

        private void DrawHorizontal(int x, int y)
        {
            for (int i = 0; i < x; i++)
            {
                Point p = (i, y, ch);
                p.Draw();
                wall.Add(p);
            }
        }
        private void DrawVertical(int x, int y)
        {
            for (int i = InitialParametrs.initialY + 1; i < y; i++)
            {
                Point p = (x, i, ch);
                p.Draw();
                wall.Add(p);
            }
        }

        public bool IsHit(Point p)
        {
            foreach (var w in wall)
            {
                if (p == w)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
