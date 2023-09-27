using API.Model.DTO;
using API.Repo;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("Info")]
    public class InfoController : Controller
    {
        private readonly IInfoRepo infoRepo;
        private readonly IMapper mapper;
        public InfoController(IInfoRepo infoRepo, IMapper mapper)
        {
            this.mapper = mapper;
            this.infoRepo = infoRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllInfo()
        {
            var info = await infoRepo.GetAllInfoAsync();
            var infoDTO = mapper.Map<List<Model.DTO.Info>>(info);

            return Ok(infoDTO);
        }

        [HttpGet]

        [Route("{id:int}")]  // restrict to take only guid values
        [ActionName("GetInfoByID")]
        public async Task<IActionResult> GetInfoById(int id)
        {
            var info = await infoRepo.GetInfoById(id);
            if (info == null)
            {

                return BadRequest();
            }
            var infoDTO = mapper.Map<Model.DTO.Info>(info);

            return Ok(infoDTO);
        }


        [HttpPost]
        public async Task<IActionResult> AddInfo (AddInfo AddInfo)
        {
            var info = new Model.Domain.Info()
            // convert DTO to Domain
            {
                id = AddInfo.id,
                FirstName = AddInfo.FirstName,
                LastName = AddInfo.LastName
            };
            // pass to repo
            info = await infoRepo.AddInfo(info);

            // pass domain to DTO

            var infoDTO = new Model.Domain.Info()
            {
                id = info.id,
                FirstName = info.FirstName,
                LastName = info.LastName
            };


            return CreatedAtAction(nameof(AddInfo), new { id = infoDTO.id }, infoDTO);

            //return Ok(info);
        }


        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteInfoById (int id)
        {

           await infoRepo.DeleteInfoById(id);

            var info = await infoRepo.GetAllInfoAsync();


            return Ok(info);
        }

        [HttpPut]
        [Route ("{id :int}")]
        public async Task<IActionResult> UpdateInfoById(int id, Info info)
        {

            var infoDomain = new Model.Domain.Info()
            {
                id = info.id,
                FirstName = info.FirstName,
                LastName = info.LastName


            };
           var Updatedinfo = await infoRepo.UpdateInfoById(id, infoDomain);


            if (Updatedinfo != null)
            {
                var infoDTO = new Model.Domain.Info()
                {
                    id = Updatedinfo.id,
                    FirstName = Updatedinfo.FirstName,

                    LastName = Updatedinfo.LastName

                };

                return Ok(infoDTO);
            }

            return NotFound();
        }



    }
}
