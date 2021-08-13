using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class CreateFolder : IPathFolder
    {
        public string pathFolder { get; set; } = $@"{Directory.GetCurrentDirectory()}\SavedData";

        public CreateFolder()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(pathFolder);
            if (!dirInfo.Exists)
                dirInfo.Create();
        }
    }
}
