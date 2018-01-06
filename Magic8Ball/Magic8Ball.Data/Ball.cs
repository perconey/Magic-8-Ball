using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic8Ball.Data
{
    class Ball
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
            string str = "2";
            return str;
        }

    }
}
