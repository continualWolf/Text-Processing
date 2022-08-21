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
        public List<DataInput> DataList { get; set; }

        public List<WordValues> WordValues { get; set; }

        //Initialise class / Create new instance of lists
        public DataProcessor()
        {
            DataList = new List<DataInput>();
            WordValues = new List<WordValues>();
        }

        public void ProcessData(DataInput data)
        {
            if(data == null || data.Text == "" || data.Text == null)
                return;

            DataList.Add(data);

            //break text input into words
            string[] words = data.Text.Split(' ');

            foreach (string word in words)
            {
                // if word already exists in table
                var temp = WordValues.FirstOrDefault(i => i.Word == word);
                if (temp != null)
                {
                    var tempVal = temp.Values.FirstOrDefault(i => i.Value == data.Value);
                    if (tempVal != null)
                    {
                        tempVal.IncreaseCount(1);
                    }
                    else
                    {
                        ValuesCount newValue = new ValuesCount(data.Value, 1);
                        temp.Values.Add(newValue);
                    }
                            
                }
                else
                {
                    WordValues newWord = new WordValues(word);
                    ValuesCount newValue = new ValuesCount(data.Value, 1);
                    List <ValuesCount> values = new List<ValuesCount> { newValue };
                    newWord.Initialise(values);

                    WordValues.Add(newWord);
                }
            }
        }
    }
}
