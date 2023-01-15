using API.Model.Domain;
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
    }
}
