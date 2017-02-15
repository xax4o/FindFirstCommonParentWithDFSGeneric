namespace FindFirstCommonParentWithDFSGeneric.ConsoleUI.Contracts
{
    using FindFirstCommonParentWithDFSGeneric.ConsoleUI.Commands.Contracts;

    public interface ICommandFactory
    {
        ICommand CreateCommand(string commandName);
    }
}
