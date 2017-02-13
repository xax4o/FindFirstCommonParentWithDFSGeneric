namespace FindFirstCommonParentWithDFSGeneric.Logic
{
    using System.Collections.Generic;

    using FindFirstCommonParentWithDFSGeneric.Models.Contracts;
    using FindFirstCommonParentWithDFSGeneric.Logic.Contracts;

    public class DFSTreeTraversal : ITreeTraversal
    {
        private ICollection<INode> visiedTreeNodes;

        public DFSTreeTraversal()
        {
            this.visiedTreeNodes = new HashSet<INode>();
        }

        public ICollection<INode> TraversalTree(INode startNode)
        {
            this.visiedTreeNodes.Clear();
            this.depthFirstSearch(startNode);

            return this.visiedTreeNodes;
        }

        private void depthFirstSearch(INode startNode)
        {
            this.visiedTreeNodes.Add(startNode);

            for (int i = 0; i < startNode.NumberOfChildren; i++)
            {
                this.depthFirstSearch(startNode.GetChild(i));
            }
        }
    }
}
