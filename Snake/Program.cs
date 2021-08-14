﻿using System;
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
        public static void Main()
        {
            CreateFolder.Create();
            CheckWindowSize.Value();

            Game game = new Game();
            game.Play();
        }      
    }  
}
