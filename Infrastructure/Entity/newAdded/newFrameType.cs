using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entity.newAdded
{
    public class newFrameType : EntityBase<int>
    {
        public string? Title { get; set; }
        public double PerUnit { get; set; }
        public double Value { get; set; }
        public double lib { get; set; }
    }
}