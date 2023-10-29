using API.Model.Domain;
using API.Model.DTO;
using API.Repo;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    
    [ApiController]
    [Route("Image")]
    public class ImageController : Controller
    {
        private IImage image;

        public ImageController(IImage image)
        {
            this.image = image;
        }

        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> upLoad([FromForm] ImageDTO imageDTO)
        {
            Validate(imageDTO);
            if (ModelState.IsValid)
            {
                //upload to repo
                var imageDomainModel = new Image
                {
                    File = imageDTO.File,
                    fileDescription = imageDTO.fileDescription,
                    fileExtension = Path.GetExtension(imageDTO.File.FileName),
                    fileName = imageDTO.fileName,
                    fileSizeInBytes = imageDTO.fileSizeInBytes

                };
                await image.upload(imageDomainModel);


                return Ok(imageDomainModel);
            }
            return BadRequest();

        }

        private void Validate(ImageDTO imageDTO)
        {
            var allowedExtensions = new string[] { ".jpg", ".jpeg", ".png" };

            if (!allowedExtensions.Contains(Path.GetExtension(imageDTO.File.FileName)))
            {
                ModelState.AddModelError("file", "unsupported format");
            }
        }
    }
}
