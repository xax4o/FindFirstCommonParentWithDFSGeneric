namespace FindFirstCommonParentWithDFSGeneric.ConsoleUI
{
    using System;
    using System.Threading;

    using FindFirstCommonParentWithDFSGeneric.ConsoleUI.Commands;
    using FindFirstCommonParentWithDFSGeneric.ConsoleUI.Commands.Contracts;
    using FindFirstCommonParentWithDFSGeneric.ConsoleUI.ConsoleIO;
    using FindFirstCommonParentWithDFSGeneric.Data.Repositories;
    using FindFirstCommonParentWithDFSGeneric.Logic;
    using FindFirstCommonParentWithDFSGeneric.Models.Contracts;

    public class Startup
    {
        public static void Main()
        {
            var nodes = new GenericRepositoryWithDictionary<INode>();

            while (true)
            {
                Console.WriteLine("1. Add nodes");
                Console.WriteLine("2. Get common node");
                Console.WriteLine("3. Exit");

                Console.Write("Choose: ");
                var command = Console.ReadLine();
                ICommand commandType;

                if (command == "1")
                {
                    commandType = new AddCommand(nodes, new ConsoleWriter(), new ConsoleReader());
                }
                else if (command == "2")
                {
                    var finder = new FirstCommonNodeFinder(nodes, new DFSTreeTraversal(), new RootNodeFinder());
                    commandType = new GetFirstCommonNodeCommand(finder, new ConsoleWriter(), new ConsoleReader());
                }
                else if (command == "3")
                {
                    Console.WriteLine("Good Bye");
                    break;
                }
                else
                {
                    Console.WriteLine("No such command");
                    Thread.Sleep(2000);
                    Console.Clear();
                    continue;
                }

                commandType.Execute();
                Thread.Sleep(4000);
                Console.Clear();
            }
        }
    }
}
