using Text_Processing;

DataProcessor processor = new DataProcessor();
processor.ProcessData(new DataInput("The film was good.", 1));
processor.ProcessData(new DataInput("The film was bad.", 0));

foreach (var item in processor.WordValues)
{
    Console.WriteLine($"word : {item.Word}");
    Console.WriteLine(" Value | Count");
    Console.WriteLine("---------------");
    foreach (var values in item.Values)
    {
        Console.WriteLine($"   {values.Value}   |   {values.Count}");
    }
    Console.WriteLine("-------------------------------");
}

Console.ReadLine();