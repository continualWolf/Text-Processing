using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Processing
{
    public class ValuesCount
    {
        public int Value { get;set; }

        public double Count { get; set; }

        public ValuesCount(int value, double count)
        {
            Value = value;
            Count = count;
        }

        /// <summary>
        /// Increase the value of count by the parameter 'by'
        /// </summary>
        public void IncreaseCount(int by)
        {
            Count = Count + by;
        }

        /// <summary>
        /// Decrease the value of count by the parameter 'by'
        /// </summary>
        public void DecreaseCount(int by)
        {
            Count = Count - by;
        }
    }
}
