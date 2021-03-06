﻿namespace FindFirstCommonParentWithDFSGeneric.Logic
{
    using System;

    using FindFirstCommonParentWithDFSGeneric.Models.Contracts;
    using FindFirstCommonParentWithDFSGeneric.Logic.Contracts;
    using FindFirstCommonParentWithDFSGeneric.Data.Repositories.Contracts;

    public class RootNodeFinder : IRootNodeFinder
    {
        public INode GetRootNode(IGenericRepository<INode> data)
        {
            var nodes = data.GetAll();

            foreach (var node in nodes)
            {
                if (!node.HasParent)
                {
                    return node;
                }
            }

            throw new ArgumentException("There is no root node");
        }
    }
}
