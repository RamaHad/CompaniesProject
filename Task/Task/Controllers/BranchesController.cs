using Dto;
using IRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchesController : ControllerBase
    {
        private readonly IBranchIRepo _repo;

        public BranchesController(IBranchIRepo repo)
        {
            _repo = repo;
        }
        [HttpPost]
        public IActionResult AddMainBranches(MainBranchDto dto)
        {
            if (dto.Name == null || dto.Name.Length == 0 )
                return BadRequest("You must insert main branch name!");

            var result = _repo.AddMainBranches(dto);
            if (result == null)
                return NotFound("you must insert true company ID!");
            return Ok(result);

        }

        [HttpPost("AddDistributionBranches")]
        public IActionResult AddDistributionBranches(DistributionBranchDto dto)
        {
            if (dto.Name == null || dto.Name.Length == 0)
                return BadRequest("You must insert distribution branch name!");

            var result = _repo.AddDistributionBranches(dto);
            if (result == null)
                return NotFound("you must insert true main branch ID!");
            return Ok(result);

        }
    }
}
