using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepo
{
    public interface IDistributionIRepo
    {
        public DistributionDto? Add(DistributionDto dto);
        public IQueryable<DistributionsDetailsDto> SelectDetails(DistributionsDetailsDto dto);
    }
}
