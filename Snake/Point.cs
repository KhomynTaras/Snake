using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    struct Point
    {
        public int x { get; set; }
        public int y { get; set; }
        public string ch { get; set; }

        public static implicit operator Point((int, int, string) value)
        {
            return new Point { x = value.Item1, y = value.Item2, ch = value.Item3 };
        }
        public static bool operator ==(Point a, Point b) =>
            (a.x == b.x && a.y == b.y) ? true : false;
        public static bool operator !=(Point a, Point b) =>
            (a.x != b.x || a.y != b.y) ? true : false;

        public void Draw()
        {
            DrawPoint(ch);
        }
        public void Clear()
        {
            DrawPoint(" ");
        }
        private void DrawPoint(string _ch)
        {

            Console.SetCursorPosition(x, y);
            Console.Write(_ch);
        }
    }
}
