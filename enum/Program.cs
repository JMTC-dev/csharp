Console.WriteLine(Warning.CodeYellow);

var status = Warning.CodeYellow;

if (status == Warning.CodeYellow)
{
    Console.WriteLine("Code Yellow");
}
enum Warning
{
    CodeRed,
    CodeBlue,
    CodeYellow
}