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

        public DataProcessor()
        {
            DataList = new List<DataInput>();
        }

        public void ProcessData(DataInput data)
        {
            if(data == null || data.Text == "" || data.Text == null)
                return;

            //Remove numbers and special characters from input text
            Regex reg = new Regex("[*'\",_&#^@$-.0-9]");
            data.Text = reg.Replace(data.Text, string.Empty);

            var filePath = "C:/Users/bmwat/source/repos/Text_Processing/Text_Processing/stop_words.txt";

            string[] tempData = data.Text.Split(' ');
            List<string> file = File.ReadAllLines(filePath).ToList();
            for (int i = 0; i < tempData.Length; i++)
            {
                if (file.Contains(tempData[i]))
                {
                    tempData[i] = "";
                }
            }

            data.Text = string.Join(" ", tempData);
            data.Text = data.Text.TrimEnd();
            data.Text = data.Text.TrimStart();
            data.Text = data.Text.Replace("  ", " ");

            DataList.Add(data);
        }
    }
}
