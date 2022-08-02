using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class DistributionDto
    {
        public DateTime DateOfDistribution { get; set; }
        public int Amount { get; set; }
        public Guid ProductionId { get; set; }
        public Guid DistributionBranchId { get; set; }
    }
}
