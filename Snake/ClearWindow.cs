using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class ClearWindow
    {
        public static void Clear()
        {

            for(int i = 0; i <= CheckWindowSize.WindowWidth; i++)
            {
                for (int j = 0; j <= CheckWindowSize.WindowHeight; j++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write("  ");
                }
            }

            Console.CursorVisible = true;
        }
    }
}
