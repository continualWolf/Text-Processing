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
    }
}
