using API.Data;
using API.Model.Domain;

namespace API.Repo
{
    public class ImageRepo : IImage
    {
        private IWebHostEnvironment webHostEnvironment;
        private APIDBContext aPIDBContext;
        private IHttpContextAccessor httpContextAccessor;

        public ImageRepo(IWebHostEnvironment webHostEnvironment ,APIDBContext aPIDBContext , IHttpContextAccessor httpContextAccessor)
        {
           this.webHostEnvironment = webHostEnvironment;
            this.aPIDBContext = aPIDBContext;
            this.httpContextAccessor = httpContextAccessor;     
        }
        public async Task<Image> upload(Image image)
        {
            // put file in localpath
            var localPathFile = Path.Combine(webHostEnvironment.ContentRootPath, "Image",
                $"{image.fileName}{image.fileExtension}");
            // upload file to local path
           using var stream = new FileStream(localPathFile,FileMode.Create);

            await image.File.CopyToAsync(stream);

            //https://localhost:7005/image/image.jpeg

            var urlFilePath = $"{httpContextAccessor.HttpContext.Request.Scheme}://" +
                $"{httpContextAccessor.HttpContext.Request.Host}{httpContextAccessor.HttpContext.Request.PathBase}" +
                $"/Image/{image.fileName}{image.fileExtension}";
            image.filePath = urlFilePath;   

            //add image to table
             aPIDBContext.Image.Add(image);
            aPIDBContext.SaveChanges();

            return image;
        }
    }
}
