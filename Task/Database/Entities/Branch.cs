using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Entities
{
    public class Branch
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string  Location { get; set; }

        public Branch MainBranch { get; set; }
        public Guid MainBranchId { get; set; }

        public Company Company { get; set; }
        public Guid CompanyId { get; set; }



    }
}
