using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepo
{
    public interface IBranchIRepo
    {
        public MainBranchDto? AddMainBranches(MainBranchDto dto);
        public DistributionBranchDto? AddDistributionBranches(DistributionBranchDto dto);

    }
}
