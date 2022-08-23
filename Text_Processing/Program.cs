using System.Text.RegularExpressions;
using Text_Processing;

//test data
//-------------------------------
DataProcessor processor = new DataProcessor();

var testDataFP = "C:\\Users\\Benjamin\\Downloads\\sentiment labelled sentences\\sentiment labelled sentences\\imdb_labelled.txt";
List<string> testData = File.ReadAllLines(testDataFP).ToList();
for (int i = 0; i < testData.Count; i++)
{
    var text = testData[i];
    int value = Int32.Parse(testData[i].Substring(testData[i].Length - 1));
    text = text.Replace(text.Substring(text.Length - 1), "");
    processor.ProcessData(new DataInput(text, value));
}

//take input for text you want to predict
string input = "";
Console.Write("Please input text : ");
input = Console.ReadLine().ToLower();

//Remove numbers and special characters from input text
Regex reg = new Regex("[*'\",_&#^@$-.0-9]");
input = reg.Replace(input, string.Empty);

var filePath = "C:\\Users\\Benjamin\\Documents\\GitHub\\Text-Processing\\Text_Processing\\stop_words.txt";

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
input = Functions.JoinWords(tempData);

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


