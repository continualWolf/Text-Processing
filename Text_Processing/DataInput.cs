using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            Text = input.ToLower();
            Value = inputValue;
        }
    }
}
