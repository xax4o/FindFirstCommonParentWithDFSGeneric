namespace FindFirstCommonParentWithDFSGeneric.ConsoleUI.ConsoleIO
{
    using System;

    using FindFirstCommonParentWithDFSGeneric.ConsoleUI.ConsoleIO.Contracts;

    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            var text = Console.ReadLine();

            return text;
        }
    }
}
