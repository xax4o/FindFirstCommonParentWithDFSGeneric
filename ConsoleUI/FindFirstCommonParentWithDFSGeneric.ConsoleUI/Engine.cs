namespace FindFirstCommonParentWithDFSGeneric.ConsoleUI
{
    using System;
    using System.Threading;

    using FindFirstCommonParentWithDFSGeneric.ConsoleUI.Commands.Contracts;
    using FindFirstCommonParentWithDFSGeneric.ConsoleUI.Contracts;
    using FindFirstCommonParentWithDFSGeneric.ConsoleUI.ConsoleIO.Contracts;

    public class Engine : IEngine
    {
        private ICommandFactory commandFactory;
        private IWriter outputWriter;
        private IReader inputReader;
        private IClearer outputClearer;

        public Engine(ICommandFactory commandFactory, IWriter writer, IReader reader, IClearer clearer)
        {
            this.commandFactory = commandFactory;
            this.outputWriter = writer;
            this.inputReader = reader;
            this.outputClearer = clearer;
        }

        public void Run()
        {
            while (true)
            {
                this.outputWriter.WriteLine("1. Add nodes");
                this.outputWriter.WriteLine("2. Get common node");
                this.outputWriter.WriteLine("3. Exit");

                this.outputWriter.Write("Choose: ");
                var command = this.inputReader.ReadLine();

                if (command == "3")
                {
                    this.outputWriter.WriteLine("Good Bye");
                    break;
                }

                ICommand commandType;
                try
                {
                    commandType = this.commandFactory.CreateCommand(command);
                }
                catch (ArgumentException)
                {
                    this.outputWriter.WriteLine("Invalid command");
                    Thread.Sleep(1000);
                    this.outputClearer.Clear();
                    continue;
                }

                commandType.Execute();

                Thread.Sleep(4000);
                this.outputClearer.Clear();
            }
        }
    }
}
