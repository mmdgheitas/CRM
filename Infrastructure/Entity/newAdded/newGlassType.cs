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
        public int Priority { get; set; }
        public int perUnit { get; set; }
        public int lib { get; set; }
    }
}