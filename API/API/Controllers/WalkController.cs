using API.Repo;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    [ApiController]
    [Route("Walk")]
    public class WalkController : Controller
    {
        private readonly IWalkRepo walkRepo;
        private readonly IMapper mapper;

        public WalkController(IWalkRepo walkRepo, IMapper mapper) { 
         this.walkRepo = walkRepo;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWalkAsync()
        {
            var walk = await walkRepo.GetWalkByID();
            var walkDTO = mapper.Map<List<Model.DTO.Walk>>(walk);

            return Ok(walkDTO); 
        }

        [HttpGet]
        [Route("{id:guid}")]  // restrict to take only guid values
        [ActionName("GetWalkByID")]
        public async Task<IActionResult> GetWalkByIdAsync(Guid id)
        {
            var walk = await walkRepo.GetWalkByID(id);
            if (walk == null)
            {
                return NotFound();
            }

            var walkDTO = mapper.Map<List<Model.DTO.Walk>>(walk);
            return Ok(walkDTO);
        }
    }
}
