namespace FindFirstCommonParentWithDFSGeneric.Data.Repositories.Contracts
{
    using System.Collections.Generic;

    using FindFirstCommonParentWithDFSGeneric.Models.Contracts;

    public interface IGenericRepository<TNode>
        where TNode : INode
    {
        void Add(string index, TNode entity);

        TNode GetByIndex(string index);

        IDictionary<string, TNode> GetAll();

        bool Contains(string index);
    }
}
