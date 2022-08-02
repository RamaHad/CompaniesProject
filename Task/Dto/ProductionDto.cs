using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class ProductionDto
    {
        public int Amount { get; set; }
        public DateTime DateOfProduction { get; set; }
        public Guid ItemId { get; set; }
        public Guid BranchId { get; set; }
    }
}
