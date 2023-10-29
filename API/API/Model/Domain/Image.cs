using System.ComponentModel.DataAnnotations.Schema;

namespace API.Model.Domain
{
    public class Image
    {
        public Guid  id { get; set; }
        
        [NotMapped]
        public IFormFile File { get; set; }

        public string fileName { get; set; }

        public string? fileDescription { get; set; }

        public string fileExtension { get; set; }

        public string fileSizeInBytes  { get; set; }

        public string filePath { get; set; }

    }
}
