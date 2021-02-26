using System;
using System.Collections.Generic;

namespace Model
{
    public class FrameModel: Model
    {
        public string Name { get; set; }
        public string Info { get; set; }
        public string Description { get; set; }
        public FrameTypeModel FrameType { get; set; }
    }
}