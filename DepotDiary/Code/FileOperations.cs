using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepotDiary.Code
{
    public class FileOperations
    {
        public void WriteFromList(List<string> list, string fName)
        {
            string outputPath = string.Format(@"C:\Users\peter.holliday\OneDrive - FM Conway Ltd\SQL Scripts\Calendar\{0}.sql", fName);
            using(StreamWriter writer = new StreamWriter(outputPath)) 
            {
                foreach(string item in list)
                {
                    writer.WriteLine(item);
                }
            }
        }
    }
}
