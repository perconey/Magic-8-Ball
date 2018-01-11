using System;
using System.Collections.Generic;


namespace Magic8Ball.Data
{
    public static class SentenceImporter
    {
        private static List<KeyValuePair<int, string>> _importedSentences = null;
        public static int ISLenght = 0;
        public static List<KeyValuePair<int, string>> ImportedSentences
        {
            get
            {
                //not thread safe
                if(_importedSentences == null)
                {
                    _importedSentences = ImportSentences();
                }
                return _importedSentences;
            }
            set
            {
                _importedSentences = ImportSentences();
            }
        }

        public static List<KeyValuePair<int, string>> ImportSentences()
        {
            int currentReadingState = 0, sentencesCount = 0;
            
            var ret = new List<KeyValuePair<int, string>>();
            try
            {
                 string[] lines = System.IO.File.ReadAllLines("Resources/sentences.txt");
                 for (int i = 0; i < lines.Length; i ++)
                 {
                     var isNumeric = int.TryParse(lines[i], out var n);
                     if (isNumeric)
                     {
                         currentReadingState++;
                     }
                     else
                     {
                         sentencesCount++;
                         ret.Add(new KeyValuePair<int, string>(currentReadingState, lines[i]));
                     }
                 }

            }catch(Exception ex)
            {
                ret.Add(new KeyValuePair<int, string>(0, "error"));
            }
            ISLenght = ret.Count;
            return ret;
        }
    }
}
