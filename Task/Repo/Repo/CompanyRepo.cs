
namespace Repo.Repo
{
    public class CompanyRepo : ICompanyIRepo
    {
        private readonly ApplicationDbContext _context;

        public CompanyRepo()
        {
            _context = new ApplicationDbContext();
        }

        public CompanyDto Add(CompanyDto dto)
        {
            try
            {
                Company company = new();
                Guid guid = Guid.NewGuid();
                company.Id = guid;
                company.Name = dto.Name;
                company.Activity = dto.Activity;
                company.Location = dto.Location;
                company.Created = dto.Created;
                _context.Add(company);
                _context.SaveChanges();
                return dto;
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
