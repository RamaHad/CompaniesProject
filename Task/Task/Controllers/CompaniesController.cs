using Dto;
using IRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyIRepo _repo;

        public CompaniesController(ICompanyIRepo repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public IActionResult AddCompany(CompanyDto dto)
        {
            if(dto.Name==null || dto.Name.Length==0)
              return BadRequest("You must insert company name!");
            
            var result = _repo.Add(dto);
            return Ok(result);
        }
    }
}
