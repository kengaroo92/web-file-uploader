namespace web_file_uploader.Controllers
{
    public class HomeController : Controller
    {
        // IWebHostEnvironment is used to access the web root path. This injects it into the controller.
        // Without this code, we can't access the root of the file path that we need to send to the handler for processing.
        private readonly IWebHostEnvironment _environment;
        public HomeController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public IActionResult Index()
        {
            return View("Index");
        }

        // Identify an action that supports the HTTP POST method. The handler is written using the HTTP protocol, and the method used to upload the files is a POST method.
        [HttpPost]
        // IFormFileCollection is a collection of the IFormFile object. Which is the equivalent to formData object in vanilla JavaScript.
        public async Task<IActionResult> UploadFiles(IFormFileCollection files)
        {
            // Get the physical path to the file's destination folder.
            //var folderPath = Path.Combine(_environment.WebRootPath, "uploads");
            var folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));

            // If the directory doesn't exist, create the directory.
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            // Iterate through the files in the IFormFileCollection.
            foreach (var file in files)
            {
                // Get the name of each file in the collection.
                var fileName = Path.GetFileName(file.FileName);

                // Get the physical path to the files destination.
                //var filePath = Path.Combine(folderPath, fileName);
                var filePath = Path.Combine(folderPath, fileName);

                if (file != null && file.Length > 0)
                {
                    // Save the files to the server.
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        // The await task is used to allow each file to finish saving before the method continues.
                        await file.CopyToAsync(fileStream);
                    }
                }
            }

            // The following code will send the binary data to the external file handler using the HttpClient.
            //using (var client = new HttpClient())
            //{
            //    var formData = new MultipartFormDataContent();

            //    foreach (var file in files)
            //    {
            //        formData.Add(new StreamContent(file.OpenReadStream()), "file", file.FileName);
            //    }

            //    var response = await client.PostAsync("http://INSERSERVERHERE.NET/Handler.ashx", formData);

            //    if (!response.IsSuccessStatusCode)
            //    {
            //        return BadRequest("An error has occurred while uploading the files.");
            //    }
            //}

            //return Ok("The files were successfully uploaded.");
            return View("Success");
        }
    }
}
