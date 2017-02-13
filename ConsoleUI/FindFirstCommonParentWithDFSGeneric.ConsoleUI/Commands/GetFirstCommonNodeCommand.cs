namespace FindFirstCommonParentWithDFSGeneric.ConsoleUI.Commands
{
    using FindFirstCommonParentWithDFSGeneric.ConsoleUI.Commands.Contracts;
    using FindFirstCommonParentWithDFSGeneric.ConsoleUI.ConsoleIO.Contracts;
    using FindFirstCommonParentWithDFSGeneric.Logic.Contracts;

    public class GetFirstCommonNodeCommand : ICommand
    {
        private IFirstCommonNodeFinder commonNodeFinder;
        private IWriter outputWriter;
        private IReader inputReader;

        public GetFirstCommonNodeCommand(IFirstCommonNodeFinder firstNodeFinder, IWriter writer, IReader reader)
        {
            this.commonNodeFinder = firstNodeFinder;
            this.outputWriter = writer;
            this.inputReader = reader;
        }

        public void Execute()
        {
            this.outputWriter.Write("Enter first node to search: ");
            var firstSearchedNode = this.inputReader.ReadLine();

            this.outputWriter.Write("Enter second node to search: ");
            var secondSearchedNode = this.inputReader.ReadLine();

            var result = this.commonNodeFinder.Find(firstSearchedNode, secondSearchedNode);

            this.outputWriter.WriteLine(string.Format("The first common node of {0} and {1} is {2}", firstSearchedNode, secondSearchedNode, result.Name));
        }
    }
}
