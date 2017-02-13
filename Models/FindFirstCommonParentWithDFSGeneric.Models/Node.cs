namespace FindFirstCommonParentWithDFSGeneric.Models
{
    using System.Collections.Generic;

    using FindFirstCommonParentWithDFSGeneric.Models.Contracts;

    public class Node : INode
    {
        private IList<INode> children;

        public Node(string name)
        {
            this.Name = name;
            this.HasParent = false;
            this.children = new List<INode>();
        }

        public string Name { get; private set; }

        public bool HasParent { get; set; }

        public int NumberOfChildren
        {
            get
            {
                return this.children.Count;
            }
        }

        public void AddChild(INode node)
        {
            this.children.Add(node);
        }

        public INode GetChild(int index)
        {
            return this.children[index];
        }
    }
}
