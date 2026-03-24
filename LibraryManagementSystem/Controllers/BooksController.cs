using LibraryManagementSystem.Data;
using LibraryManagementSystem.Entity;
using LibraryManagementSystem.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryManagementSystem.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context;
        

        private readonly IFileUploadService _fileUploadService;

        public BooksController(ApplicationDbContext context,
            IFileUploadService fileUploadService)
        {
            _context = context;
            _fileUploadService = fileUploadService;
        }

        public IActionResult Index()
        {
            var dataList = _context.Books.ToList();
         
            return View(dataList);
        }


        public IActionResult CreateBook()
        {
            var categoryList = _context.Categories.Where(x => x.IsActive == true).ToList();
            // <option value="1">Male</option>
            ViewBag.CategoryList = new SelectList(categoryList, "CategoryId", "Name");

            return View();
        }

        public async Task<IActionResult> CreateBookSubmit(Book book, IFormFile coverPhoto, IFormFile ThumnailPhoto,double Price2)
        {
            ///uploads/coverPhoto/31d4beb5-4d56-475d-9174-e53e3ea8b264.jpg

            if (coverPhoto != null)
                book.CoverUrl =  await _fileUploadService.UploadFileAsync(coverPhoto, "coverPhoto");


            _context.Books.Add(book);
            _context.SaveChanges();


            return RedirectToAction("Index");
        }

     

    }
}
