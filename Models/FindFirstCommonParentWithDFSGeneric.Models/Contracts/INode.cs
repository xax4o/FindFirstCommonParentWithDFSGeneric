namespace FindFirstCommonParentWithDFSGeneric.Models.Contracts
{
    public interface INode
    {
        string Name { get; }

        bool HasParent { get; set; }

        int NumberOfChildren { get; }

        void AddChild(INode node);

        INode GetChild(int index);
    }
}
