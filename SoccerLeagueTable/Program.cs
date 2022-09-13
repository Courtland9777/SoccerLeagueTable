using System.Text;

const string file = @"football.dat";
if (File.Exists(file))
{
    var teamName = string.Empty;
    var minSpan = 1000;
    var footballData = File.ReadLines(file, Encoding.UTF8);
    
    foreach (var line in footballData.Skip(1))
    {
        if(line.Contains("---")) continue;
        
        var lineArr = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var tempSpan = Math.Abs(int.Parse(lineArr[6][..2]) - int.Parse(lineArr[8][..2]));
        if (tempSpan < minSpan)
        {
            minSpan = tempSpan;
            teamName = lineArr[1];
        }
    }
    Console.WriteLine($"The team with the minimum span is {teamName}");
}
else
{
    Console.WriteLine("{file} doesn't exist.");
}