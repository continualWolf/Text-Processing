using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using Text_Processing;

DataProcessor processor = new DataProcessor();

var testDataFP = "C:\\Users\\Benjamin\\Documents\\GitHub\\Text-Processing\\Text_Processing\\imdb_labelled.txt";
var testDataFP2 = "C:\\Users\\Benjamin\\Documents\\GitHub\\Text-Processing\\Text_Processing\\yelp_labelled.txt";
var testDataFP3 = "C:\\Users\\Benjamin\\Documents\\GitHub\\Text-Processing\\Text_Processing\\amazon_cells_labelled.txt";
List<string> testData = File.ReadAllLines(testDataFP).ToList();
List<string> testData2 = File.ReadAllLines(testDataFP2).ToList();
List<string> testData3 = File.ReadAllLines(testDataFP3).ToList();
testData.AddRange(testData2);
testData.AddRange(testData3);
for (int i = 0; i < testData.Count; i++)
{
    if (testData[i] != "")
    {
        var text = testData[i];
        int value = Int32.Parse(testData[i].Substring(testData[i].Length - 1));
        text = text.Replace(text.Substring(text.Length - 1), "");
        processor.ProcessData(new DataInput(text, value));
    }
}


//   The following tests are in the case of + or - texts 

List<string> successRate = new List<string>();

string test1 = EntryPoint.ReturnMostProbableOutcome("It was a wonderful day", processor) == 1 ? "Success" : "Fail";
Console.WriteLine($"Test 1 : {test1}");
successRate.Add(test1);

string test2 = EntryPoint.ReturnMostProbableOutcome("It was a awful day", processor) == 0 ? "Success" : "Fail";
Console.WriteLine($"Test 2 : {test2}");
successRate.Add(test2);

string test3 = EntryPoint.ReturnMostProbableOutcome("Today, i hated how the staff treated me! I will never go back.", processor) == 0 ? "Success" : "Fail";
Console.WriteLine($"Test 3 : {test3}");
successRate.Add(test3);

string test4 = EntryPoint.ReturnMostProbableOutcome("We all had the best day out ever!! It was perfect.", processor) == 1 ? "Success" : "Fail";
Console.WriteLine($"Test 4 : {test4}");
successRate.Add(test4);

string test5 = EntryPoint.ReturnMostProbableOutcome("Such a bad expereince, i do not recommend !", processor) == 0 ? "Success" : "Fail";
Console.WriteLine($"Test 5 : {test5}");
successRate.Add(test5);

string test6 = EntryPoint.ReturnMostProbableOutcome("I loved every second of the film, if you have not seen it i recommend buying tickets Now!", processor) == 1 ? "Success" : "Fail";
Console.WriteLine($"Test 6 : {test6}");
successRate.Add(test6);

string test7 = EntryPoint.ReturnMostProbableOutcome("I did somewhat enjoy the film, but overall the film was rubbish.", processor) == 0 ? "Success" : "Fail";
Console.WriteLine($"Test 7 : {test7}");
successRate.Add(test7);

string test8 = EntryPoint.ReturnMostProbableOutcome("Why was the film so bad, my god. They had four years to complete it.", processor) == 0 ? "Success" : "Fail";
Console.WriteLine($"Test 8 : {test8}");
successRate.Add(test8);

Console.ReadLine();

//string input = "";
//Console.Write("Cameron input your opinion : ");
//input = Console.ReadLine();
//EntryPoint.PrintProbabilities(input, processor);
