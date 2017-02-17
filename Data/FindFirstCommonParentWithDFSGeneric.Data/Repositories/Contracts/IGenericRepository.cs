namespace FindFirstCommonParentWithDFSGeneric.Data.Repositories.Contracts
{
    using System.Collections.Generic;

    using FindFirstCommonParentWithDFSGeneric.Models.Contracts;

    public interface IGenericRepository<TNode>
        where TNode : INode
    {
        void Add(TNode entity);

        TNode GetByIndex(string index);

        ICollection<TNode> GetAll();

        bool Contains(string index);
    }
}
