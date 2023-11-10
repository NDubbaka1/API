using Microsoft.AspNetCore.Mvc;

namespace APIUI.Controllers
{
    public class RegionController : Controller
    {
        public IHttpClientFactory httpClientFactory { get; set; }
        public RegionController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }


        public async Task<IActionResult> Index()
        {
            try
            {
                var client = httpClientFactory.CreateClient();
                var httpResponseMessage = await client.GetAsync("https://localhost:7005/Region");
                httpResponseMessage.EnsureSuccessStatusCode();
              
            }
            catch (Exception ex)
            {

                throw;
            }
            return View();
        }
    }
}
