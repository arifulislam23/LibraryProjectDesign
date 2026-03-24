namespace LibraryManagementSystem.Service
{
    public class FileUploadService : IFileUploadService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileUploadService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }


        public async Task<string> UploadFileAsync(IFormFile file, string folderName)
        {

            if (file == null || file.Length == 0)
                return null;

            //uploads/book-1.jpg

            //8be4df61-93ca-11d2-aa0d-00e098032b8.jpg
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

            //folderName: wwwroot/uploads/coverPhoto
            string uploadFoler = Path.Combine(_webHostEnvironment.WebRootPath,"uploads", folderName);

            if (!Directory.Exists(uploadFoler))
            {
                Directory.CreateDirectory(uploadFoler);
            }

            //wwwroot/uploads/coverPhoto/8be4df61-93ca-11d2-aa0d-00e098032b8.jpg
            string filePath = Path.Combine(uploadFoler, fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            

            return "/uploads/" + folderName + "/" + fileName;



        }
    }
}
