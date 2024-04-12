using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entity.newAdded
{
    public class newGlassType : EntityBase<int>
    {
        public string? Title { get; set; }
        public double Priority { get; set; }
        public double perUnit { get; set; }
        public double lib { get; set; }
    }
}