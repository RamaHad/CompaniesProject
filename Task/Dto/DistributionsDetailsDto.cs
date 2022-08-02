using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class DistributionsDetailsDto
    {
        public Guid? MainBranchesId { get; set; }
        public string? DistributionBranchName { get; set; }
        public string? ItemName { get; set; }
        public int? Amount { get; set; }
        public DateTime? DistributionDate { get; set; }
        public DateTime? LastDateOfProduction { get; set; }
    }
}
