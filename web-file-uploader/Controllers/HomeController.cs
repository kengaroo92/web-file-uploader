namespace web_file_uploader.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //return Content("Adding this string for testing purposes to see if my Controller is properly routed.");
            return View("Index");
        }

        public IActionResult UploadFiles(IFormFileCollection files)
        {
            return View();
        }
    }
}
