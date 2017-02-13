namespace FindFirstCommonParentWithDFSGeneric.Logic.Contracts
{
    using FindFirstCommonParentWithDFSGeneric.Models.Contracts;

    public interface IFirstCommonNodeFinder
    {
        INode Find(string firstSearchedNode, string secondSearchedNode);
    }
}
