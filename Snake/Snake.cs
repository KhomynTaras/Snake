using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    enum Direction
    {
        LEFT,
        RIGHT,
        UP,
        DOWN
    }
    class Snake
    {
        public static List<Point> snake { get; private set; }
        private Direction direction;
        private int step = 1;
        private Point tail;
        private Point head;
        bool rotate = true;
        public Snake(int [,] arr)
        {
            int iRow = arr.GetUpperBound(0);

            if (arr[iRow, 0] > arr[iRow - 1, 0])
                direction = Direction.RIGHT;
            else if (arr[iRow, 0] < arr[iRow - 1, 0])
                direction = Direction.LEFT;
            else if (arr[iRow, 1] > arr[iRow - 1, 1])
                direction = Direction.UP;
            else
                direction = Direction.DOWN;

            snake = new List<Point>();
            for (int i = 0; i <= arr.GetUpperBound(0); i++)
            {
                Point p = (arr[i,0], arr[i, 1], "*");
                snake.Add(p);
                p.Draw();
            }
        }
        public Snake(int x, int y, int length)
        {
            direction = Direction.RIGHT;
            snake = new List<Point>();
            for (int i = x - length; i < x; i++)
            {
                Point p = (i, y, "*");
                snake.Add(p);
                p.Draw();
            }
        }
        public Point GetHead() => snake.Last();
        public void Move()
        {
            head = GetNextPoint();
            snake.Add(head);
            tail = snake.First();
            snake.Remove(tail);
            tail.Clear();
            head.Draw();
            rotate = true;
        }
        public Point GetNextPoint()
        {
            Point p = GetHead();
            switch (direction)
            {
                case Direction.LEFT:
                    p.x -= step;
                    break;
                case Direction.RIGHT:
                    p.x += step;
                    break;
                case Direction.UP:
                    p.y -= step;
                    break;
                case Direction.DOWN:
                    p.y += step;
                    break;
            }
            return p;
        }
        public void Rotation(string m)
        {
            if (rotate)
            {
                switch (direction)
                {
                    case Direction.LEFT:
                    case Direction.RIGHT:
                        if (m == "D")
                            direction = Direction.DOWN;
                        else if (m == "U")
                            direction = Direction.UP;
                        break;
                    case Direction.UP:
                    case Direction.DOWN:
                        if (m == "L")
                            direction = Direction.LEFT;
                        else if (m == "R")
                            direction = Direction.RIGHT;
                        break;
                }
                rotate = false;
            }
        }
        public bool IsHit(Point p)
        {
            for (int i = snake.Count - 2; i > 0; i--)
            {
                if (snake[i] == p)
                {               
                    return true;
                }
            }
            return false;
        }

        public bool Eat(Point p)
        {
            head = GetNextPoint();
            if (head == p)
            {
                snake.Add(head);
                head.Draw();
                FoodGeneration.PointsCounter();
                return true;
            }
            return false;
        }


    }
}
