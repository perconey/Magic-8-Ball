using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic8Ball.Data
{
    public static class SentenceImporter
    {
        public static List<KeyValuePair<int, string>> importedSentences = null;

        public static List<KeyValuePair<int, string>> ImportSentences()
        {
            List<KeyValuePair<int, string>> ret = null;
            string[] lines = System.IO.File.ReadAllLines("Resources/sentences.txt");
            foreach(string line in lines)
            {
                ret.Add(new KeyValuePair<int, string>(1, line));
            }

            return ret;
        }
    }
}
