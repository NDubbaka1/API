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
    }
}
