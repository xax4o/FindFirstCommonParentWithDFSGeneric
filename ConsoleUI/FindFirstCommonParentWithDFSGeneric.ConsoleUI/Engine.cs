namespace FindFirstCommonParentWithDFSGeneric.ConsoleUI
{
    using System;
    using System.Threading;

    using FindFirstCommonParentWithDFSGeneric.ConsoleUI.Commands;
    using FindFirstCommonParentWithDFSGeneric.ConsoleUI.Commands.Contracts;
    using FindFirstCommonParentWithDFSGeneric.ConsoleUI.ConsoleIO;
    using FindFirstCommonParentWithDFSGeneric.Data.Repositories.Contracts;
    using FindFirstCommonParentWithDFSGeneric.Logic.Contracts;
    using FindFirstCommonParentWithDFSGeneric.Models.Contracts;
    using FindFirstCommonParentWithDFSGeneric.ConsoleUI.Contracts;

    public class Engine : IEngine
    {
        private ICommandFactory commandFactory;

        public Engine(ICommandFactory commandFactory)
        {
            this.commandFactory = commandFactory;        
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("1. Add nodes");
                Console.WriteLine("2. Get common node");
                Console.WriteLine("3. Exit");

                Console.Write("Choose: ");
                var command = Console.ReadLine();
                
                if (command == "3")
                {
                    Console.WriteLine("Good Bye");
                    break;
                }

                ICommand commandType;
                try
                {
                    commandType = this.commandFactory.CreateCommand(command);
                }
                catch(ArgumentException)
                {
                    Console.WriteLine("Invalid command");
                    Thread.Sleep(1000);
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
