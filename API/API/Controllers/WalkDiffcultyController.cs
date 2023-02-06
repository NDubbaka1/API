using API.Model.Domain;
using API.Model.DTO;
using API.Repo;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    [ApiController]
    [Route("WalkDiffculty")]
    public class WalkDiffcultyController :Controller
    {
        private readonly IWalkDiffRepo walkDiffRepo;
        private readonly IMapper Mapper;

        public WalkDiffcultyController(IWalkDiffRepo walkDiffRepo, IMapper Mapper)
        {
            this.walkDiffRepo=walkDiffRepo;
            this.Mapper = Mapper;
        }

        [HttpGet]

        public async Task<IActionResult> GetAllWalkDiff()
        {
            var walkDiffculty = await walkDiffRepo.GetAllWalkDiff();
            var walkDiffcultyDTO = Mapper.Map<List<Model.DTO.WalkDiffculty>>(walkDiffculty);

            return Ok(walkDiffcultyDTO);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        [ActionName("GetWalkDiffcultyByID")]
        public async Task<IActionResult> GetWalkDiffcultyByID(Guid Id)
        {
            var walkDiffculty = await walkDiffRepo.GetWalkDiffculty(Id);
            var walkDiffcultyDTO = Mapper.Map<Model.DTO.WalkDiffculty>(walkDiffculty);
            return Ok(walkDiffcultyDTO);
        }

        [HttpPost]
        public async Task<IActionResult> AddWalkDiffculty(AddWalkDiffculty addWalkDiffculty)
        {
            //Request DTO to model
            var walkdiffculty = new Model.Domain.WalkDiffculty()
            {
                Code= addWalkDiffculty.Code
            };


            //pass to repo
           walkdiffculty= await walkDiffRepo.AddWalkDiffculty(walkdiffculty);

            //conver model to DTO

            var walkdiffcultyDTO = new Model.DTO.WalkDiffculty()
            {
                Id= walkdiffculty.Id,
                Code = walkdiffculty.Code
            };

            return CreatedAtAction(nameof(GetWalkDiffcultyByID), new {Id = walkdiffcultyDTO.Id }, walkdiffcultyDTO);
        }
    }
}
