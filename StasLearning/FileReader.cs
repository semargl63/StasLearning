using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StasLearning
{
    class FileReader
    {
        public string ReadFile(Uri fileUri)
        {
            return string.Empty;
        }

        public string ReadFile(string filepath)
        {
            var result = string.Empty;

            if (!File.Exists(filepath))
            {
                Console.WriteLine("File is not exist");
            }
            else
            {
                using (var reader = new StreamReader(filepath))
                {
                    result = reader.ReadToEnd();
                }
            }

            return result;
        }
    }
}
