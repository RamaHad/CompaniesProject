using Dto;
using IRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemIRepo _repo;

        public ItemsController(IItemIRepo repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public IActionResult AddCompany(ItemDto dto)
        {
            if (dto.Name == null || dto.Name.Length == 0)
                return BadRequest("You must insert Item name!");

            var result = _repo.Add(dto);
            return Ok(result);
        }
    }
}
