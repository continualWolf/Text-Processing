using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Text_Processing
{
    public class DataInput
    {
        public string? Text { get; set; }

        //In this example, the value will be 1 or 0 (Positive or Negative)
        public int Value { get; set; }

        public DataInput(string input, int inputValue)
        {
            //Remove numbers and special characters from input text
            Regex reg = new Regex("[*'\",_&#^@$-.0-9]");
            input = reg.Replace(input, string.Empty);
            input = input.ToLower();

            //var filePath = "C:/Users/bmwat/source/repos/Text_Processing/Text_Processing/stop_words.txt";
            var filePath = "C:\\Users\\Benjamin\\Documents\\GitHub\\Text-Processing\\Text_Processing\\stop_words.txt";

            string[]words = Functions.RemoveStopWords(input, filePath);

            input = Functions.JoinWords(words);

            Text = input;
            Value = inputValue;
        }
    }
}
