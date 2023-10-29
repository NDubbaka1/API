using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Model.DTO
{
    public class ImageDTO
    {

        [Required]
        public IFormFile File { get; set; }
        [Required]
        public string? fileName { get; set; }

        public string? fileDescription { get; set; }

        public string? fileExtension { get; set; }

        public string? fileSizeInBytes { get; set; }
    }
}
