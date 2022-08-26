using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Text_Processing
{
    public class DataProcessor
    {
        public List<WordValues> WordValues { get; set; }

        public List<int> ValueTypes { get; set; }

        /// <summary>
        /// Initialise class / Create new instance of lists
        /// </summary>
        public DataProcessor()
        {
            WordValues = new List<WordValues>();
            ValueTypes = new List<int>();
        }
        
        /// <summary>
        /// Processes data set, passes each line as a parameter to the ProcessData function
        /// </summary>
        /// <param name="filePaths"></param>
        public void AddDataSet(params string[] filePaths)
        {
            if (filePaths == null)
                return;

            List<string> lines = new List<string>();

            foreach (string filePath in filePaths)
            {
                lines.AddRange(File.ReadAllLines(filePath).ToList());
            }

            for (int i = 0; i < lines.Count(); i++)
            {
                if (lines[i] != "")
                {
                    var text = lines[i];
                    int value = Int32.Parse(lines[i].Substring(lines[i].Length - 1));
                    text = text.Replace(text.Substring(text.Length - 1), "");
                    ProcessData(new DataInput(text, value));
                }
            }
        }

        /// <summary>
        /// Breaks down data/text given into words and adds them to 'WordValues'
        /// </summary>
        /// <param name="data"></param>
        public void ProcessData(DataInput data)
        {
            if(data == null || data.Text == "" || data.Text == null)
                return;

            if (!ValueTypes.Contains(data.Value))
            {
                ValueTypes.Add(data.Value);
            }
            //break text input into words
            string[] words = data.Text.Split(' ');

            //process the words
            foreach (string word in words)
            {
                // if word already exists in table
                var existingWord = WordValues.FirstOrDefault(i => i.Word == word);
                if (existingWord != null)
                {
                    var existingWordValue = existingWord.Values.FirstOrDefault(i => i.Value == data.Value);
                    if (existingWordValue != null)
                    {
                        existingWordValue.IncreaseCount(1);
                    }
                    else
                    {
                        ValuesCount newValue = new ValuesCount(data.Value, 1);
                        existingWord.Values.Add(newValue);
                    }
                            
                }
                else
                {
                    //if list of words does not contain the current word
                    //create a new word item
                    WordValues newWord = new WordValues(word);

                    //create a value list then initialise the word with said value
                    List <ValuesCount> values = new List<ValuesCount> { new ValuesCount(data.Value, 1) };
                    newWord.Initialise(values);

                    //add the new word to the list of words that have assigned values
                    WordValues.Add(newWord);
                }
            }

            //process phrases
            for (int i = 0; i < words.Length - 1; i++)
            {
                var pharse = $"{words[i]} {words[i + 1]}";

                // if word already exists in table
                var existingWord = WordValues.FirstOrDefault(i => i.Word == pharse);
                if (existingWord != null)
                {
                    var existingWordValue = existingWord.Values.FirstOrDefault(i => i.Value == data.Value);
                    if (existingWordValue != null)
                    {
                        existingWordValue.IncreaseCount(1);
                    }
                    else
                    {
                        existingWord.Values.Add(new ValuesCount(data.Value, 1));
                    }
                }
                else
                {
                    //if list of words does not contain the current word
                    //create a new word item
                    WordValues newWord = new WordValues(pharse);

                    //create a value list then initialise the word with said value
                    List<ValuesCount> values = new List<ValuesCount> { new ValuesCount(data.Value, 1) };
                    newWord.Initialise(values);

                    //add the new word to the list of words that have assigned values
                    WordValues.Add(newWord);
                }
            }
        }
    }
}
