namespace FindFirstCommonParentWithDFSGeneric.ConsoleUI.ConsoleIO
{
    using System;

    using FindFirstCommonParentWithDFSGeneric.ConsoleUI.ConsoleIO.Contracts;

    public class Writer : IWriter
    {
        public void Write(string text)
        {
            Console.Write(text);
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
