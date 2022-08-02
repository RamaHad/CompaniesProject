using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Entities
{
    public class Distribution
    {
        public Guid Id { get; set; }
        public DateTime DateOfDistribution { get; set; }
        public int Amount { get; set; }

        public Production Production { get; set; }
        public Guid ProductionId { get; set; }

        public Branch DistributionBranch { get; set; }
        public Guid DistributionBranchId { get; set; }

    }
}
