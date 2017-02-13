namespace FindFirstCommonParentWithDFSGeneric.Logic.Contracts
{
    using System.Collections.Generic;

    using FindFirstCommonParentWithDFSGeneric.Models.Contracts;

    public interface ITreeTraversal
    {
        ICollection<INode> TraversalTree(INode startNode);
    }
}
