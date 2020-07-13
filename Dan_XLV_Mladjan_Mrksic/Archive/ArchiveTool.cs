using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dan_XLV_Mladjan_Mrksic.Archive
{
    /// <summary>
    /// Class Archive writes all actions to text file
    /// </summary>
    class ArchiveTool
    {
        StreamWriter sw;
        string path = @".../.../ManagerArchive.txt";
        /// <summary>
        /// Method that writes to file
        /// </summary>
        /// <param name="input">Input parameter is a string that will get written to file</param>
        public void WriteToFile(string input)
        {
            if (!File.Exists(path)) File.Create(path);
            sw = new StreamWriter(@".../.../ManagerArchive.txt", append: true);
            using (sw)
            {
                sw.WriteLine(input);
            }
        }
    }
}
