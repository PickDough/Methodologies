using System;
using System.Collections.Generic;
using System.Linq;
using Methodology.LAB01.Interfaces;

namespace Methodology.LAB01.Classes
{
    public class DataContainer<T>: IDataContainer<T> where T: ContainerItem
    {
        private List<T> _items;

        public DataContainer()
        {
            _items = new List<T>();
        }
        
        public void Add(T item)
        {
            _items.Add(item);
        }

        public T Get(Guid id)
        {
            return _items.FirstOrDefault(t => t.Id == id);
        }

        public List<T> GetAll()
        {
            return _items;
        }
        
        
    }
}