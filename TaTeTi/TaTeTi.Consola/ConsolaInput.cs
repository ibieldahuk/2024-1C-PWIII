// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");


internal interface IConsolaInput
{
    string ReadLine();
}

internal class ConsolaInput : IConsolaInput
{
    public string ReadLine()
    {
        return Console.ReadLine();
    }
}