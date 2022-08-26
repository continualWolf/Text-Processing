using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Processing
{
    public class Functions
    {
        public static string JoinWords(string[] arrayOfWords)
        {
            string cleanedUpText;
            cleanedUpText = string.Join(" ", arrayOfWords);
            cleanedUpText = cleanedUpText.TrimEnd();
            cleanedUpText = cleanedUpText.TrimStart();
            cleanedUpText = cleanedUpText.Replace("  ", " ");

            return cleanedUpText;
        }

        /// <summary>
        /// Removes the stop words in the text file thats passed as a parameter
        /// </summary>
        /// <param name="text"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string[] RemoveStopWords(string text, string filePath)
        {
            string[] words = text.Split(' ');
            List<string> file = File.ReadAllLines(filePath).ToList();
            for (int i = 0; i < words.Length; i++)
            {
                if (file.Contains(words[i]))
                {
                    words[i] = "";
                }
            }

            return (words);
        }
    }
}
