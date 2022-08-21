using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Processing
{
    public class WordValues
    {
        public string Word { get; set; }

        public List<ValuesCount> Values { get; set; }

        public WordValues(string word)
        {
            Word = word;
            Values = new List<ValuesCount>();
        }
        public void Initialise(List<ValuesCount>? values)
        {
            if(values != null)
                Values = values;
        }

        public double WordValueTotal()
        {
            return Values.Sum(i => i.Count);
        }
    }
}
