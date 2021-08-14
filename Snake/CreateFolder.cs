using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class CreateFolder 
    {
        public static string pathFolder { get; set; } = $@"{Directory.GetCurrentDirectory()}\SavedData";

        public static void Create()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(pathFolder);
            if (!dirInfo.Exists)
                dirInfo.Create();
        }
    }
}
