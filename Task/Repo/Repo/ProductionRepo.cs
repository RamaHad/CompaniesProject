using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Repo
{
    public class ProductionRepo : IProductionIRepo
    {
        private readonly ApplicationDbContext _context;

        public ProductionRepo()
        {
            _context = new ApplicationDbContext();
        }

        public ProductionDto? Add(ProductionDto dto)
        {
            try
            {
                //itemId validation
                var item = _context.Items.SingleOrDefault(b => b.Id == dto.ItemId);
                if (item == null) return null;

                //mainBranchID validation
                var branch = _context.Branches.SingleOrDefault(b => b.Id == dto.BranchId && b.Id==b.MainBranchId);
                if (branch == null) return null;

                //add the production
                Production production = new();
                Guid guid= Guid.NewGuid();
                production.Id = guid;
                production.DateOfProduction = dto.DateOfProduction;
                production.ItemId = dto.ItemId;
                production.Amount = dto.Amount;
                production.BranchId = dto.BranchId; 
                _context.Add(production);
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
