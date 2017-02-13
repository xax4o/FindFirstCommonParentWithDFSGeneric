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
            this.outputWriter.Write("Enter a");
            var a = this.inputReader.ReadLine();

            this.outputWriter.Write("Enter b");
            var b = this.inputReader.ReadLine();

            var result = this.commonNodeFinder.Find(a, b);

            this.outputWriter.WriteLine(result.Name);
        }
    }
}
