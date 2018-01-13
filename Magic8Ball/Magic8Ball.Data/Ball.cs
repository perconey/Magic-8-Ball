using System;
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
            var imps = SentenceImporter.ImportedSentences;
            var len = SentenceImporter.ISLenght;
            ChosenSentence = imps[GetRandomNumber(0, len - 1)].Value;
            return ChosenSentence;
        }

    }
}
