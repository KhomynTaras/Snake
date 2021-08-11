using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class WindowSize
    {
        public const int WindowWidth = 90;
        public const int WindowHeight = 30;
        public static void Value()
        {
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    if (Console.WindowHeight > WindowHeight || Console.WindowWidth > WindowWidth || Console.WindowHeight < WindowHeight || Console.WindowWidth < WindowWidth)
                    {
                        Console.SetWindowSize(WindowWidth, WindowHeight);
                        Console.SetBufferSize(WindowWidth + 1, WindowHeight + 1);
                    }
                }
            });
        }       
    }
}
