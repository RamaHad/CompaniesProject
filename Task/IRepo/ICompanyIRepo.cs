using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepo
{
    public interface ICompanyIRepo
    {
        public CompanyDto Add(CompanyDto dto);
    }
}
