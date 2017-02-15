namespace FindFirstCommonParentWithDFSGeneric.ConsoleUI.ConsoleIO
{
    using System;

    using FindFirstCommonParentWithDFSGeneric.ConsoleUI.ConsoleIO.Contracts;

    public class ConsoleClearer : IClearer
    {
        public void Clear()
        {
            Console.Clear();
        }
    }
}
