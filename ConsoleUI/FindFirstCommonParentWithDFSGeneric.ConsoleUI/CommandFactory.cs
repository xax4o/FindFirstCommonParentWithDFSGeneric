namespace FindFirstCommonParentWithDFSGeneric.ConsoleUI
{
    using System;

    using FindFirstCommonParentWithDFSGeneric.ConsoleUI.Commands;
    using FindFirstCommonParentWithDFSGeneric.ConsoleUI.Commands.Contracts;
    using FindFirstCommonParentWithDFSGeneric.ConsoleUI.ConsoleIO.Contracts;
    using FindFirstCommonParentWithDFSGeneric.Data.Repositories.Contracts;
    using FindFirstCommonParentWithDFSGeneric.Logic.Contracts;
    using FindFirstCommonParentWithDFSGeneric.Models.Contracts;
    using FindFirstCommonParentWithDFSGeneric.ConsoleUI.Contracts;

    public class CommandFactory : ICommandFactory
    {
        private IGenericRepository<INode> data;
        private IFirstCommonNodeFinder finder;
        private IWriter outputWriter;
        private IReader inputReader;
        private ICommand addCommand;
        private ICommand getFirstCommonNodeCommand;

        public CommandFactory(IGenericRepository<INode> data, IFirstCommonNodeFinder finder, IWriter writer, IReader reader)
        {
            this.data = data;
            this.finder = finder;
            this.outputWriter = writer;
            this.inputReader = reader;
        }

        public virtual ICommand CreateCommand(string command)
        {
            ICommand commandType;

            if (command == "1")
            {
                if (this.addCommand == null)
                {
                    this.addCommand = new AddCommand(this.data, this.outputWriter, this.inputReader);
                }

                commandType = this.addCommand;
            }
            else if (command == "2")
            {
                if (this.getFirstCommonNodeCommand == null)
                {
                    this.getFirstCommonNodeCommand = new GetFirstCommonNodeCommand(this.finder, this.outputWriter, this.inputReader);
                }
                commandType = this.getFirstCommonNodeCommand;
            }
            else
            {
                throw new ArgumentException("Invalid command!");
            }

            return commandType;
        }
    }
}
