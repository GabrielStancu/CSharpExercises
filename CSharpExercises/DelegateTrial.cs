using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExercises
{
    class DelegateTrial
    {
        private delegate void DisplayDictionaryDelegate(Dictionary<int, string> words );

        private void DisplayDictionary(Dictionary<int, string> words)
        {
            foreach(KeyValuePair<int, string> entry in words)
            {
                Console.WriteLine($"Key: {entry.Key}, Value: {entry.Value}");
            }
        }

        public void Run()
        {
            Dictionary<int, string> Words = new Dictionary<int, string>()
            {
                [1] = "The",
                [2] = "dictionary",
                [3] = "is",
                [4] = "initialized"
            };

            DisplayDictionaryDelegate display = new DisplayDictionaryDelegate(DisplayDictionary);
            display(Words);
        }
    }
}
