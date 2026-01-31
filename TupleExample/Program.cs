var values = ("t", 2, "p");

Console.WriteLine(values.Item1);

var valuesWithName = (First: "t", Second: "third", Third: "fourth");

(int a, string b, bool c) ReturnTheseValues()
{
    return (9, "u", true);
}


var (a, b, c) = ReturnTheseValues();

Console.WriteLine(a);

