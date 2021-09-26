using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ShieldRPG.Repositories
{
    public class WordsRepository
    {
        private readonly string[] _wordList;

        public WordsRepository()
        {
            _wordList = File.ReadAllText(@"Data\Wordlist.txt").Split(" ");
        }

        public List<string> GetWords(int count, int length)
        {
            List<string> result = new List<string>();
            Random rand = new Random();
            int i = 0, failsafe = 0;

            do
            {
                int index = rand.Next(0, _wordList.Length);
                int wordlen = _wordList[index].Length;

                if (wordlen == length) {
                    result.Add(_wordList[index].ToLower());
                    i++;
                }
                else
                {
                    failsafe++;
                }

                if (failsafe > 1000) { i = failsafe; }

            } while (i < count);

            return result;
        }
    }
}
