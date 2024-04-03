// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");


internal interface IConsolaOutput
{
    public void Write(string mensaje);
    public void WriteLine(string mensaje);
    public void Clear();
}

internal class ConsolaOutput : IConsolaOutput
{
    public void Write(string mensaje)
    {
        Console.Write(mensaje);
    }

    public void WriteLine(string mensaje)
    {
        Console.WriteLine(mensaje);
    }

    public void Clear()
    {
        Console.Clear();
    }
}