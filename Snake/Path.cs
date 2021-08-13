using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    abstract class Path
    {
        public static readonly string pathTxtFileSavedData = $@"{Directory.GetCurrentDirectory()}\SavedData\SavedData.txt";
        public static readonly string pathTxtFileMaxPointsCount = $@"{Directory.GetCurrentDirectory()}\SavedData\MaxPointsCount.txt";
    }
}
