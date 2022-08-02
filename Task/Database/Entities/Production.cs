using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Entities
{
    public class Production
    {
        public Guid Id { get; set; }
        public int  Amount { get; set; }
        public DateTime DateOfProduction { get; set; }

        public Item Item { get; set; }
        public Guid ItemId { get; set; }

        public Branch Branch { get; set; }
        public Guid BranchId { get; set; }
    }
}
