namespace FindFirstCommonParentWithDFSGeneric.Logic
{
    using System;
    using System.Collections.Generic;

    using FindFirstCommonParentWithDFSGeneric.Logic.Contracts;
    using FindFirstCommonParentWithDFSGeneric.Models.Contracts;
    using FindFirstCommonParentWithDFSGeneric.Data.Repositories.Contracts;

    public class FirstCommonNodeFinder : IFirstCommonNodeFinder
    {
        private IGenericRepository<INode> data;
        private ITreeTraversal treeTraversal;
        private IRootNodeFinder rootNodeFinder;

        public FirstCommonNodeFinder(IGenericRepository<INode> data, ITreeTraversal traversalTree, IRootNodeFinder rootNodeFinder)
        {
            this.data = data;
            this.treeTraversal = traversalTree;
            this.rootNodeFinder = rootNodeFinder;
        }

        public INode Find(string firstSearchedNode, string secondSearchedNode)
        {
            if (!(this.data.Contains(firstSearchedNode) 
                && this.data.Contains(secondSearchedNode)))
            {
                return null;
            }

            if (firstSearchedNode.Equals(secondSearchedNode))
            {
                return this.data.GetByIndex(firstSearchedNode);
            }

            var currentIndex = 0;
            var rootNode = this.rootNodeFinder.GetRootNode(this.data);
            var firstNode = data.GetByIndex(firstSearchedNode);
            var secondNode = data.GetByIndex(secondSearchedNode);

            while (true)
            {
                ICollection<INode> visitedNodes;

                if (currentIndex < rootNode.NumberOfChildren)
                {
                    visitedNodes = this.treeTraversal.TraversalTree(rootNode.GetChild(currentIndex));
                }
                else
                {
                    throw new NullReferenceException("No such child");
                }

                if (visitedNodes.Contains(firstNode)
                    && visitedNodes.Contains(secondNode))
                {
                    rootNode = rootNode.GetChild(currentIndex);
                    currentIndex = -1;
                }
                else if (visitedNodes.Contains(firstNode)
                    || visitedNodes.Contains(secondNode))
                {
                    return rootNode;
                }

                currentIndex++;
            }
        }
    }
}
