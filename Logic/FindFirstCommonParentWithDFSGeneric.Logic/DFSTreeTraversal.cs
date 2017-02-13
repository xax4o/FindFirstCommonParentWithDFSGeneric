namespace FindFirstCommonParentWithDFSGeneric.Logic
{
    using System.Collections.Generic;

    using FindFirstCommonParentWithDFSGeneric.Models.Contracts;
    using FindFirstCommonParentWithDFSGeneric.Logic.Contracts;

    public class DFSTreeTraversal : ITreeTraversal
    {
        private ICollection<INode> traversaledTreeNodes;

        public DFSTreeTraversal()
        {
            this.traversaledTreeNodes = new HashSet<INode>();
        }

        public ICollection<INode> TraversalTree(INode startNode)
        {
            this.traversaledTreeNodes.Clear();
            this.depthFirstSearch(startNode);

            return this.traversaledTreeNodes;
        }

        private void depthFirstSearch(INode startNode)
        {
            this.traversaledTreeNodes.Add(startNode);

            for (int i = 0; i < startNode.NumberOfChildren; i++)
            {
                depthFirstSearch(startNode.GetChild(i));
            }
        }
    }
}
