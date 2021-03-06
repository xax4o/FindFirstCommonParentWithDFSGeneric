﻿namespace FindFirstCommonParentWithDFSGeneric.Data.Repositories
{
    using System;
    using System.Collections.Generic;

    using FindFirstCommonParentWithDFSGeneric.Data.Repositories.Contracts;
    using FindFirstCommonParentWithDFSGeneric.Models.Contracts;

    public class GenericRepositoryWithDictionary<TNode> : IGenericRepository<TNode>
        where TNode : INode
    {
        private IDictionary<string, TNode> data;

        public GenericRepositoryWithDictionary()
            : this(new Dictionary<string, TNode>())
        {
        }

        public GenericRepositoryWithDictionary(IDictionary<string, TNode> data)
        {
            this.data = data;
        }

        public void Add(TNode entity)
        {
            if (this.data != null)
            {
                this.data.Add(entity.Name, entity);
            }
            else
            {
                throw new NullReferenceException("The collection is not valid");
            }
        }

        public TNode GetByIndex(string index)
        {
            if (this.Contains(index))
            {
                return this.data[index];
            }

            throw new NullReferenceException("No such index");
        }

        public ICollection<TNode> GetAll()
        {
            if (this.data != null)
            {
                var dataToReturn = this.data.Values;

                return dataToReturn;
            }

            throw new NullReferenceException("The collection is not valid");
        }

        public bool Contains(string index)
        {
            return this.data.ContainsKey(index);
        }
    }
}
