using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Repo
{
    public class BranchRepo : IBranchIRepo
    {
        private readonly ApplicationDbContext _context;

        public BranchRepo()
        {
            _context = new ApplicationDbContext();
        }

        public DistributionBranchDto? AddDistributionBranches(DistributionBranchDto dto)
        {
            try
            {
                //mainBranchID validation
                var mainBranches = _context.Branches.SingleOrDefault(b => b.Id == dto.MainBranchId);
                if (mainBranches == null) return null;

                //add Distribution branch
                Branch distributionBranch = new();
                Guid guid = Guid.NewGuid();
                distributionBranch.Id=guid;
                distributionBranch.Name=dto.Name;   
                distributionBranch.Location=dto.Location;
                distributionBranch.MainBranchId=dto.MainBranchId;
                var localVariable = _context.Branches.First(b => b.MainBranchId == dto.MainBranchId);
                distributionBranch.CompanyId = localVariable.CompanyId; // set the company of Distribution branch like the company of main branch
                _context.Add(distributionBranch);
                _context.SaveChanges();
                return dto;

            }
            catch(Exception)
            {
                throw;
            }
        }

        public MainBranchDto? AddMainBranches(MainBranchDto dto)
        {
            try
            {
                //companyID validation
                var company = _context.Companies.SingleOrDefault(b => b.Id == dto.CompanyId);
                if (company == null)  return null;

                //add the mainBranch
                Branch mainBranch = new();
                Guid guid = Guid.NewGuid();
                mainBranch.Id = guid;
                mainBranch.Name = dto.Name;
                mainBranch.Location = dto.Location;
                mainBranch.CompanyId = dto.CompanyId;
                mainBranch.MainBranchId = guid; // to know that this branch is main branch => let the MainbranchId == it's ID
                _context.Add(mainBranch);
                _context.SaveChanges();
                return dto;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
