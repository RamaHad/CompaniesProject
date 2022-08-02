using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class CompanyDto
    {
        public string? Name { get; set; }
        public string? Location { get; set; }
        public DateTime Created { get; set; }
        public string? Activity { get; set; }
    }
}
