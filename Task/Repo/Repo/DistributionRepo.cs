using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Repo
{
    public class DistributionRepo : IDistributionIRepo
    {

        private readonly ApplicationDbContext _context;

        public DistributionRepo()
        {
            _context = new ApplicationDbContext();
        }

        public DistributionDto? Add(DistributionDto dto)
        {
            try
            {

                //DistributionBranchID validation
                var distributionBranches = _context.Branches.SingleOrDefault(b => b.Id == dto.DistributionBranchId && b.Id != b.MainBranchId);
                if (distributionBranches == null) return null;

                //ProductionID validation
                var production = _context.Productions.SingleOrDefault(b => b.Id == dto.ProductionId);
                if (production == null) return null;

                //add the Distribution
                Distribution distribution = new();
                Guid guid = Guid.NewGuid();
                distribution.Id = guid;
                distribution.DateOfDistribution = dto.DateOfDistribution;
                distribution.Amount = dto.Amount;
                distribution.ProductionId = dto.ProductionId;
                distribution.DistributionBranchId = dto.DistributionBranchId;
                _context.Add(distribution);
                _context.SaveChanges();
                return dto;
            }
            catch(Exception)
            {
                throw;
            }


        }

        public IQueryable<DistributionsDetailsDto> SelectDetails(DistributionsDetailsDto dto)
        {
            var result = _context.Distributions
                .Include(d => d.DistributionBranch)
                .Include(p => p.Production)
                .Include(i => i.Production.Item)
                .Where(m => m.Production.BranchId == dto.MainBranchesId)
                .Select(d => new DistributionsDetailsDto
                {
                    DistributionBranchName = d.DistributionBranch.Name,
                    Amount = d.Amount,
                    ItemName = d.Production.Item.Name,
                    DistributionDate = d.DateOfDistribution,
                    LastDateOfProduction = _context.Productions.Where(b => b.ItemId == d.Production.ItemId).Max(b => b.DateOfProduction)

                }
                ) ;
                
            return result;

                }
    }
}
