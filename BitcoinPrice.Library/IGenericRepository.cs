using System;
using System.Collections.Generic;
using System.Text;

namespace BitcoinPrice.Library
{
    public interface IGenericRepository<T> where T : Entity
    {
        void Add(T item);
        IEnumerable<T> GetAll();
    }
}
