namespace FindFirstCommonParentWithDFSGeneric.ConsoleUI.Commands
{
    using System;

    using FindFirstCommonParentWithDFSGeneric.Models;
    using FindFirstCommonParentWithDFSGeneric.Models.Contracts;
    using FindFirstCommonParentWithDFSGeneric.ConsoleUI.Commands.Contracts;
    using FindFirstCommonParentWithDFSGeneric.ConsoleUI.ConsoleIO.Contracts;
    using FindFirstCommonParentWithDFSGeneric.Data.Repositories.Contracts;

    public class AddCommand : ICommand
    {
        private IGenericRepository<INode> nodes;
        private IWriter outputWriter;
        private IReader inputReader;

        public AddCommand(IGenericRepository<INode> nodes, IWriter writer, IReader reader)
        {
            this.nodes = nodes;
            this.outputWriter = writer;
            this.inputReader = reader;
        }

        public void Execute()
        {
            this.outputWriter.Write("How many tree nodes you want to add?: ");

            var nodesToAdd = 0;

            try
            {
                nodesToAdd = int.Parse(this.inputReader.ReadLine());
            }
            catch(FormatException)
            {
                this.outputWriter.WriteLine("Number of nodes must be a valid Integer number");
            }

            for (int i = 0; i < nodesToAdd; i++)
            {
                this.outputWriter.Write(string.Format("Enter tree node {0} in the format /Parrent Child/: ", i + 1));
                var arguments = this.inputReader.ReadLine().Split(' ');

                var parent = string.Empty;
                var child = string.Empty;

                try
                {
                    parent = arguments[0];
                    child = arguments[1];
                }
                catch (IndexOutOfRangeException)
                {
                    this.outputWriter.WriteLine("Wrong format!");
                    i--;
                }

                INode parentNode;
                INode childNode;

                if (this.nodes.Contains(parent))
                {
                    parentNode = nodes.GetByIndex(parent);
                }
                else
                {
                    parentNode = new Node(parent.ToString());
                    nodes.Add(parent, parentNode);
                }

                if (nodes.Contains(child))
                {
                    childNode = nodes.GetByIndex(child);
                }
                else
                {
                    childNode = new Node(child.ToString());
                    nodes.Add(child, childNode);
                }

                parentNode.AddChild(childNode);
                childNode.HasParent = true;
            }

            this.outputWriter.WriteLine(nodesToAdd + " nodes aded.");
        }
    }
}
