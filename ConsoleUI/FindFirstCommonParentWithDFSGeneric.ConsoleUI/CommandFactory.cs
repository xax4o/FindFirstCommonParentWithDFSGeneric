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

        public CommandFactory(IGenericRepository<INode> data, IFirstCommonNodeFinder finder, IWriter outputWriter, IReader inputReader)
        {
            this.data = data;
            this.finder = finder;
            this.outputWriter = outputWriter;
            this.inputReader = inputReader;
        }

        public virtual ICommand CreateCommand(string commandName)
        {
            ICommand commandType;

            if (commandName == "1")
            {
                if (this.addCommand == null)
                {
                    this.addCommand = new AddCommand(this.data, this.outputWriter, this.inputReader);
                }

                commandType = this.addCommand;
            }
            else if (commandName == "2")
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
