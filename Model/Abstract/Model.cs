using System;

namespace Model
{
    public class Model: IModel
    {
        public Guid Id { get; set; } 
        public Model()
        {
            Id = new Guid();
        }
    }
}