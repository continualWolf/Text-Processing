using System.Text.RegularExpressions;
using Text_Processing;

//test data
//-------------------------------
DataProcessor processor = new DataProcessor();
processor.ProcessData(new DataInput("good.", 1));
processor.ProcessData(new DataInput("good.", 1));
processor.ProcessData(new DataInput("good.", 1));
processor.ProcessData(new DataInput("good.", 1));
processor.ProcessData(new DataInput("good.", 1));
processor.ProcessData(new DataInput("good.", 1));
processor.ProcessData(new DataInput("good.", 1));
processor.ProcessData(new DataInput("good.", 1));
processor.ProcessData(new DataInput("good.", 1));


processor.ProcessData(new DataInput("good.", 0));
processor.ProcessData(new DataInput("good.", 0));
processor.ProcessData(new DataInput("good.", 0));
processor.ProcessData(new DataInput("good.", 0));
processor.ProcessData(new DataInput("good.", 0));
processor.ProcessData(new DataInput("good.", 0));


processor.ProcessData(new DataInput("bad.", 1));
processor.ProcessData(new DataInput("bad.", 1));

processor.ProcessData(new DataInput("bad.", 0));
processor.ProcessData(new DataInput("bad.", 0));
processor.ProcessData(new DataInput("bad.", 0));
processor.ProcessData(new DataInput("bad.", 0));
processor.ProcessData(new DataInput("bad.", 0));
processor.ProcessData(new DataInput("bad.", 0));
processor.ProcessData(new DataInput("bad.", 0));
processor.ProcessData(new DataInput("bad.", 0));
processor.ProcessData(new DataInput("bad.", 0));
processor.ProcessData(new DataInput("bad.", 0));
processor.ProcessData(new DataInput("bad.", 0));

//take input for text you want to predict
string input = "";
int wantedProb = 1;
Console.Write("Please input text : ");
input = Console.ReadLine().ToLower();

//Remove numbers and special characters from input text
Regex reg = new Regex("[*'\",_&#^@$-.0-9]");
input = reg.Replace(input, string.Empty);

var filePath = "C:/Users/bmwat/source/repos/Text_Processing/Text_Processing/stop_words.txt";

//split text input into words
string[] tempData = input.Split(' ');

//store text file in a list
List<string> file = File.ReadAllLines(filePath).ToList();

//loop through text file list, if the list contains a word
//from the text input remove said word from text input
for (int i = 0; i < tempData.Length; i++)
{
    if (file.Contains(tempData[i]))
    {
        tempData[i] = "";
    }
}

// put input text back together and tidy up extra spaces
input = string.Join(" ", tempData);
input = input.TrimEnd();
input = input.TrimStart();
input = input.Replace("  ", " ");

string[] inputWordsArr = input.Split(' ');
double totalProb = 0;
foreach (var word in inputWordsArr)
{
    var temp = processor.WordValues.FirstOrDefault(i => i.Word == word);
    double placeholder;
    
    if(temp != null)
    {
            if(totalProb == 0)
            {
                placeholder = temp.WordValueTotal();
                totalProb = temp.Values.FirstOrDefault(i => i.Value == wantedProb).Count / temp.WordValueTotal();
            }else
            {
                totalProb = totalProb * (temp.Values.FirstOrDefault(i => i.Value == wantedProb).Count / temp.WordValueTotal());
            }
    }
    
}
Console.WriteLine($"Probability of '{input}' being {wantedProb}  is : {totalProb}");
Console.ReadLine();

