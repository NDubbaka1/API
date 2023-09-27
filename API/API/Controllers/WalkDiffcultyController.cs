using API.Model.Domain;
using API.Model.DTO;
using API.Repo;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    [ApiController]
    [Route("WalkDiffculty")]
    public class WalkDiffcultyController : Controller
    {
        private readonly IWalkDiffRepo walkDiffRepo;
        private readonly IMapper Mapper;

        public WalkDiffcultyController(IWalkDiffRepo walkDiffRepo, IMapper Mapper)
        {
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

            if(!ValidAddWalkDiff(addWalkDiffculty))
            {
                return BadRequest();
            }

            //Request DTO to model
            var walkdiffculty = new Model.Domain.WalkDiffculty()
            {
                Code = addWalkDiffculty.Code
            };


            //pass to repo
            walkdiffculty = await walkDiffRepo.AddWalkDiffculty(walkdiffculty);

            //conver model to DTO

            var walkdiffcultyDTO = new Model.DTO.WalkDiffculty()
            {
                Id = walkdiffculty.Id,
                Code = walkdiffculty.Code
            };

            return CreatedAtAction(nameof(GetWalkDiffcultyByID), new { Id = walkdiffcultyDTO.Id }, walkdiffcultyDTO);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteWalkDiff(Guid id)
        {
            var walkdiff = await walkDiffRepo.DeleteWalkDiff(id);

            if (walkdiff == null)
            {
                return null;
            }
            var walkdiffDTO = new Model.DTO.WalkDiffculty()
            {
                Code = walkdiff.Code,
                Id = walkdiff.Id

            };

            return Ok(walkdiffDTO);

        }


        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateWalkDiff (UpdateWalkDiff updateWalkDiff , Guid id)
        {
           
            //pass domain
            var walkDiff = new Model.Domain.WalkDiffculty()
            {
                Code = updateWalkDiff.Code

            };
            // pass domain to repo
            walkDiff = await walkDiffRepo.UpdateWalkDiffculty(walkDiff, id);

            // sent to DTO
            if (walkDiff != null)
            {
                var walkDiffDTO = new Model.DTO.WalkDiffculty()
                {
                    Id = walkDiff.Id,
                    Code = walkDiff.Code
                };
                return Ok(walkDiffDTO);
            }
            return NotFound();
        }

        #region Private methods
        //Validation for Walk diffculty

        private bool ValidAddWalkDiff(AddWalkDiffculty addWalk)
        {
            if (addWalk == null)
            {
                ModelState.AddModelError(nameof(addWalk), $"Add Walk");
            }

            if (string.IsNullOrEmpty(addWalk.Code))
            {
                ModelState.AddModelError(nameof(addWalk.Code), $"Code cannot be null");
            }


            if (ModelState.ErrorCount > 0)
            {
                return false;
            }

            return true;
        }


        private bool ValidUpdateWalkDiff(UpdateWalkDiff updateWalkDiff, Guid id)
        {
            if (updateWalkDiff == null)
            {
                ModelState.AddModelError(nameof(updateWalkDiff), $"Add Walkdiffculty");
            }

            if (string.IsNullOrEmpty(updateWalkDiff.Code))
            {
                ModelState.AddModelError(nameof(updateWalkDiff.Code), $"Code cannot be null");
            }


            if (ModelState.ErrorCount > 0)
            {
                return false;
            }

            return true;
        }
        #endregion

    }
}
