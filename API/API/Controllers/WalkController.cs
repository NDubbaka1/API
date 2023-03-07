using API.Data;
using API.Model.DTO;
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

        public WalkController(IWalkRepo walkRepo, IMapper mapper)
        {
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
            // get walk object from domian model
            var walk = await walkRepo.GetWalkByID(id);
            if (walk == null)
            {
                return NotFound();
            }
            //convert domain model to DTO
            var walkDTO = mapper.Map<List<Model.DTO.Walk>>(walk);

            //return response
            return Ok(walkDTO);
        }

        [HttpPost]
        public async Task<IActionResult> AddWalkById(AddWalk addWalk)
        {
            var walk = new Model.Domain.Walk()
            {
                Name = addWalk.Name,
                lenght = addWalk.lenght,

                RegionID = addWalk.RegionID,
                WalkdiffcultyID = addWalk.WalkdiffcultyID


            };

            //pass to repo
            walk = await walkRepo.AddWalkByID(walk);



            var walkDTO = new Model.Domain.Walk()
            {
                Id = walk.Id,
                Name = walk.Name,
                lenght = walk.lenght,

                RegionID = walk.RegionID,
                WalkdiffcultyID = walk.WalkdiffcultyID
            };


            return CreatedAtAction(nameof(GetWalkByIdAsync), new { id = walkDTO.Id }, walkDTO);
        }

        [HttpPut]
        [Route("{id :guid}")]
        public async Task<IActionResult> UpdateWalkByID(Guid id, UpdateWalk walk)
        {

            //convert  DTO to domain object
            var walkDomain = new Model.Domain.Walk()
            {
                Name = walk.Name,
                WalkdiffcultyID = walk.WalkdiffcultyID,
                lenght = walk.lenght,
                RegionID = walk.RegionID
            };

            // pass to repo
            walkDomain = await walkRepo.UpdateWalkById(id, walkDomain);
            // Check Walk is null

            if (walkDomain != null)
            {
                //Pass domain to DTO object

                var walkDTO = new Model.DTO.Walk()
                {
                    Name = walkDomain.Name,
                    WalkdiffcultyID = walkDomain.WalkdiffcultyID,
                    lenght = walkDomain.lenght,
                    RegionID = walkDomain.RegionID
                };
                return Ok(walkDTO);
            }



            return NotFound();
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteWalk(Guid id)
        {
            var walk = await walkRepo.deleteWalk(id);
            if (walk == null)
            {
                return NotFound();
            }
            var walkDTO = new Model.DTO.Walk()
            {
                Name = walk.Name,
                Id = walk.Id,


                lenght = walk.lenght,
                RegionID = walk.RegionID,

                WalkdiffcultyID = walk.WalkdiffcultyID
            };
            return Ok(walkDTO);

        }
    }
}

