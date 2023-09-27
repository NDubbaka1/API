using API.Model.Domain;
using API.Model.DTO;
using API.Repo;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{

    [ApiController]
    [Route("Region")]
    public class RegionController : Controller
    {

        
        private readonly IRegioRepo regionRepo;
        private readonly IMapper mapper;

        public RegionController(IRegioRepo regionRepo , IMapper mapper)
        {
           this.regionRepo = regionRepo;
            this.mapper = mapper;
        }
        
        

        [HttpGet]
        public async Task<IActionResult> GetAllRegion()
        {
           var Regions = await regionRepo.GetAllRegionAsync();
            var RegionsDTO =mapper.Map<List<Model.DTO.Region>>(Regions);
            return Ok(RegionsDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]  // restrict to take only guid values
        [ActionName("GetRegionByID")]
        public async Task<IActionResult> GetRegionByID(Guid id)
        {
            var Regions = await regionRepo.GetRegionByIDAsync(id );

            if (Regions == null)
            {
                return NotFound();  
            }
            var RegionsDTO = mapper.Map<Model.DTO.Region>(Regions);
            return Ok(RegionsDTO);
        }

        [HttpPost]
        public async Task<IActionResult> AddRegionAsync(AddRegion addRegion)
        {
            //// Adding Validation for Domain model
            //if (!ValiAddRegion(addRegion))
            //{
            //    return BadRequest();
            //}
            


            //Request DTO to model
            var region = new Model.Domain.Region()
            {
                Code= addRegion.Code,
                Name= addRegion.Name,  
                Lat= addRegion.Lat,
                Long= addRegion.Long,
                Area= addRegion.Area,
                Pop= addRegion.Pop
            };
            //Pass details to repository

            region =await regionRepo.AddRegionAsync(region);

            //Convert back to DTO
            var regionDTO = new Model.DTO.Region()
            {
                Code= region.Code,
                Name = region.Name,
                Lat = region.Lat,
                Long = region.Long,
                Area = region.Area,
                Pop = region.Pop
            };

            return CreatedAtAction(nameof(GetRegionByID), new { id = region.Id }, regionDTO);
        }

        [HttpDelete]
        [Route("{id:guid}")]  // restrict to take only guid values
        //[ActionName("GetRegionByID")]
        public async Task<IActionResult> DeleteRegionByID(Guid id)
        {
            var Regions = await regionRepo.DeleteRegionByID(id);

            if (Regions == null)
            {
                return NotFound();
            }

            var regionDTO = new Model.DTO.Region()
            {
               Id= Regions.Id,
                Code = Regions.Code,
                Name = Regions.Name,
                Lat = Regions.Lat,
                Long = Regions.Long,
                Area = Regions.Area,
                Pop = Regions.Pop
            };


            return Ok(regionDTO);
        }


        [HttpPut]
        [Route("{id :guid}")]

        public async Task<IActionResult> UpdateregionByID (Guid id, Model.DTO.UpdateRegion updateRegion)
        {
            //if (!ValiUpdateRegion(id, updateRegion))
            //{
            //    return BadRequest();
            //} 

            var regionDTO = new Model.Domain.Region()
            {
                Code = updateRegion.Code,
                Area = updateRegion.Area,
                Lat = updateRegion.Lat,
                Long = updateRegion.Long,
                Pop = updateRegion.Pop,
                Name = updateRegion.Name
            };

            // pass details to repository

            regionDTO = await regionRepo.UpdateRegionByID(id, regionDTO);

            //check if region is null
            if (regionDTO == null)
            {
                return NotFound();
            }

            // conver Domain back to DTO 

            var region = new Model.DTO.Region()
            {
                Id = regionDTO.Id,
                Code = regionDTO.Code,
                Name = regionDTO.Name,
                Lat = regionDTO.Lat,
                Long = regionDTO.Long,
                Area = regionDTO.Area,
                Pop = regionDTO.Pop
            };

            return Ok(regionDTO);

           
        }

      

        #region private Methods

        // Adding validation to Adding Region properties
        private bool ValiAddRegion(AddRegion addRegion)
        {
            if (addRegion == null)
            {
                ModelState.AddModelError(nameof(addRegion), $"Add region");
            }

            if (string.IsNullOrEmpty(addRegion.Code))
            {
                ModelState.AddModelError(nameof(addRegion.Code), $"{nameof(addRegion.Code)}Region code can't be empty ");
            }

            if (string.IsNullOrEmpty(addRegion.Name))
            {
                ModelState.AddModelError(nameof(addRegion.Name), $"{nameof(addRegion.Name)}Region code can't be empty ");
            }

            if (addRegion.Area <=0)
            {
                ModelState.AddModelError(nameof(addRegion.Area), $"{nameof(addRegion.Area)}Region code can't be empty ");
            }

            if (addRegion.Long <=0)
            {
                ModelState.AddModelError(nameof(addRegion.Long), $"{nameof(addRegion.Long)}Region code can't be empty ");
            }

            if (addRegion.Lat <=0)
            {
                ModelState.AddModelError(nameof(addRegion.Lat), $"{nameof(addRegion.Lat)}Region code can't be empty ");
            }

            if (addRegion.Pop <= 0)
            {
                ModelState.AddModelError(nameof(addRegion.Pop), $"{nameof(addRegion.Pop)}Region code can't be empty ");
            }

            if (ModelState.ErrorCount > 0)
            {
                return false;
            }

            return true;
        }

        private bool ValiUpdateRegion(Guid id, Model.DTO.UpdateRegion updateRegion)
        {
            if (updateRegion == null)
            {
                ModelState.AddModelError(nameof(updateRegion), $"Add region");
            }

            if (string.IsNullOrEmpty(updateRegion.Code))
            {
                ModelState.AddModelError(nameof(updateRegion.Code), $"{nameof(updateRegion.Code)}Region code can't be empty ");
            }

            if (string.IsNullOrEmpty(updateRegion.Name))
            {
                ModelState.AddModelError(nameof(updateRegion.Name), $"{nameof(updateRegion.Name)}Region code can't be empty ");
            }

            if (updateRegion.Area <= 0)
            {
                ModelState.AddModelError(nameof(updateRegion.Area), $"{nameof(updateRegion.Area)}Region code can't be empty ");
            }

            if (updateRegion.Long <= 0)
            {
                ModelState.AddModelError(nameof(updateRegion.Long), $"{nameof(updateRegion.Long)}Region code can't be empty ");
            }

            if (updateRegion.Lat == 0)
            {
                ModelState.AddModelError(nameof(updateRegion.Lat), $"{nameof(updateRegion.Lat)}Region code can't be empty ");
            }

            if (updateRegion.Pop == 0)
            {
                ModelState.AddModelError(nameof(updateRegion.Pop), $"{nameof(updateRegion.Pop)}Region code can't be empty ");
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
