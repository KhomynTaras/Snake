using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class PointsCounter
    {
        public static int GamePoints;
        public static int MaxGamePoints;
        public static void Counter()
        {
            GamePoints++;
            if (MaxGamePoints < GamePoints)
            {
                MaxGamePoints = GamePoints;
                ExportData.ExportMaxPointsCount();
            }
            HeaderText.PrintPointsCounter();
        }
        public static void Reset()
        {
            GamePoints = 0;
        }
    }
}
