using Dto;
using IRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductionsController : ControllerBase
    {
        private readonly IProductionIRepo _repo;

        public ProductionsController(IProductionIRepo repo)
        {
            _repo = repo;
        }
        [HttpPost]
        public IActionResult AddProductions(ProductionDto dto)
        {
            if (dto.Amount == 0)
                return BadRequest("You must insert production amount!");
            var result = _repo.Add(dto);
            if(result == null) return NotFound("You must insert true item ID and true main branch ID!");
            return Ok(result);
        }
    }
}
