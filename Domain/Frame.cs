using System;
using System.Collections.Generic;

namespace Domain
{
    public class Frame: Domain
    {
        public string Name { get; set; }
        public string Info { get; set; }
        public string Description { get; set; }
        public FrameType FrameType { get; set; }
    }
}