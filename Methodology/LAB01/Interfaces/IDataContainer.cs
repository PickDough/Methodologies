using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net.Sockets;

namespace Methodology.LAB01.Interfaces
{
    public interface IDataContainer<MyBased>
    {
        public void Add(MyBased item);
        public MyBased Get(Guid id);
        public List<MyBased> GetAll();
    }
}