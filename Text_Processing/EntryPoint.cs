using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Text_Processing
{
    public class EntryPoint
    {
        public static void PrintProbabilities(string input, DataProcessor processor)
        {
            //Remove numbers and special characters from input text
            Regex reg = new Regex("[*'\",_&#^@$-.0-9]");
            input = reg.Replace(input, string.Empty);

            var filePath = "C:\\Users\\Benjamin\\Documents\\GitHub\\Text-Processing\\Text_Processing\\stop_words.txt";

            string[] words = Functions.RemoveStopWords(input, filePath);

            // put input text back together and tidy up extra spaces
            input = Functions.JoinWords(words);

            string[] inputWordsArr = input.Split(' ');
            //currently only checking words
            // i need to adjust the code and include the phrases in the probability!!!!
            foreach (var item in processor.ValueTypes)
            {
                double totalProb = 0;
                foreach (var word in inputWordsArr)
                {
                    var wordInList = processor.WordValues.FirstOrDefault(i => i.Word == word);

                    if (wordInList != null)
                    {
                        var values = wordInList.Values.FirstOrDefault(i => i.Value == item);
                        if (values != null)
                        {
                            if (totalProb == 0)
                            {
                                totalProb = values.Count / wordInList.WordValueTotal();
                            }
                            else
                            {
                                totalProb = totalProb * (values.Count / wordInList.WordValueTotal());
                            }
                        }

                    }
                }
                Console.WriteLine($"Probability of '{input}' being {item}  is : {totalProb}");
            }
        }
    
        public static int ReturnMostProbableOutcome(string input, DataProcessor processor)
        {
            //Remove numbers and special characters from input text
            Regex reg = new Regex("[*'\",_&#^@$-.0-9]");
            input = reg.Replace(input, string.Empty);

            var filePath = "C:\\Users\\Benjamin\\Documents\\GitHub\\Text-Processing\\Text_Processing\\stop_words.txt";

            string[] words = Functions.RemoveStopWords(input, filePath);

            // put input text back together and tidy up extra spaces
            input = Functions.JoinWords(words);

            string[] inputWordsArr = input.Split(' ');

            //Most likley value outcome based on input text
            int value = 0;
            double probability = 0;

            //currently only checking words
            // i need to adjust the code and include the phrases in the probability!!!!
            foreach (var item in processor.ValueTypes)
            {
                double totalProb = 0;
                foreach (var word in inputWordsArr)
                {
                    var wordInList = processor.WordValues.FirstOrDefault(i => i.Word == word);

                    if (wordInList != null)
                    {
                        var values = wordInList.Values.FirstOrDefault(i => i.Value == item);
                        if (values != null)
                        {
                            if (totalProb == 0)
                            {
                                totalProb = values.Count / wordInList.WordValueTotal();
                            }
                            else
                            {
                                totalProb = totalProb * (values.Count / wordInList.WordValueTotal());
                            }
                        }

                    }
                }
                for (int k = 0; k < inputWordsArr.Count() - 1; k++)
                {
                    if(inputWordsArr[k] != "" && inputWordsArr[k + 1] != "")
                    {
                        var wordInList = processor.WordValues.FirstOrDefault(i => i.Word == $"{inputWordsArr[k]} {inputWordsArr[k + 1]}");

                        if (wordInList != null)
                        {
                            var values = wordInList.Values.FirstOrDefault(i => i.Value == item);
                            if (values != null)
                            {
                                if (totalProb == 0)
                                {
                                    totalProb = values.Count / wordInList.WordValueTotal();
                                }
                                else
                                {
                                    totalProb = totalProb * (values.Count / wordInList.WordValueTotal());
                                }
                            }

                        }
                    }
                }
                if(totalProb > probability)
                {
                    value = item;
                    probability = totalProb;
                }
            }

            return value;
        }
    }
}