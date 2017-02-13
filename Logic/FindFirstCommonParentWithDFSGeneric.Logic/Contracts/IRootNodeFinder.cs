namespace FindFirstCommonParentWithDFSGeneric.Logic.Contracts
{
    using FindFirstCommonParentWithDFSGeneric.Models.Contracts;
    using FindFirstCommonParentWithDFSGeneric.Data.Repositories.Contracts;

    public interface IRootNodeFinder
    {
        INode GetRootNode(IGenericRepository<INode> nodes);
    }
}
