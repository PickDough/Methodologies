using System;

namespace Methodology.LAB01.Classes
{
    public class ContainerItem
    {
        public Guid Id { get; }

        public ContainerItem()
        {
            Id = new Guid();
        }
    }
}