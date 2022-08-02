using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public  class DistributionBranchDto
    {
        public string? Name { get; set; }
        public string? Location { get; set; }
        public Guid MainBranchId { get; set; }

        
    }
}
