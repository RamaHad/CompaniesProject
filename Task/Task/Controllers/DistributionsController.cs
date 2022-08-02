using Dto;
using IRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistributionsController : ControllerBase
    {
        private readonly IDistributionIRepo _repo;

        public DistributionsController(IDistributionIRepo repo)
        {
            _repo = repo;
        }

        public IActionResult AddDistributions(DistributionDto dto)
        { 
            var result = _repo.Add(dto);
            if (result == null) return NotFound("You must insert true Destribution branch ID and true prodyction ID");
            return Ok(result);
        }
        [HttpGet]
        public IActionResult ViewDetails(DistributionsDetailsDto dto)
        {
            return Ok(_repo.SelectDetails(dto));
        }
    }
}
