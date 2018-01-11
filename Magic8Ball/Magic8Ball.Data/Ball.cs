using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Magic8Ball.Data
{
    public class Ball
    {
        private string chosenSentence;

        public string ChosenSentence { get => chosenSentence; set => chosenSentence = value; }

        private static readonly Random getrandom = new Random();
        private static readonly object syncLock = new object();
        public static int GetRandomNumber(int min, int max)
        {
            lock (syncLock)
            {
                return getrandom.Next(min, max);
            }
        }

        public string DrawSentence()
        {

            var query = from kvsent in SentenceImporter.ImportedSentences
                        where kvsent.Key == GetRandomNumber(1, 3)
                        select kvsent;
            var qta = query.ToArray();
            int lastEl = qta.Length - 1;
            string str = qta[GetRandomNumber(0, lastEl)].Value;
            ChosenSentence = str;
            return str;
        }

    }
}
