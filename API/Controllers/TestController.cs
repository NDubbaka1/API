using API.Repo;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("Test")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IWalkDiffRepo walkDiffRepo;
        private readonly IMapper Mapper;

        public TestController(IWalkDiffRepo walkDiffRepo, IMapper Mapper) {

            this.walkDiffRepo = walkDiffRepo;
            this.Mapper = Mapper;
        }

        [HttpGet]
        
        public async Task<IActionResult> GetAllWalkDiff()
        {
            var walkDiffculty = await walkDiffRepo.GetAllWalkDiff();
            var walkDiffcultyDTO = Mapper.Map<List<Model.DTO.WalkDiffculty>>(walkDiffculty);

            return Ok(walkDiffcultyDTO);
        }

    }
}
