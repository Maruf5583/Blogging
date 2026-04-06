using Blooging.Data;
using Blooging.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Blooging.Controllers
{
    public class PostController : Controller
    {
        private readonly AppDbContext _context;

        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string[] _allowedExtension = { ".jpg", ".jpeg", ".png" };

        public PostController(AppDbContext context , IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Create()
        {

            var postViewModel = new PostviewModel();

            postViewModel.Categories = _context.Categories.Select(c =>
            new SelectListItem
            {
                
                Value = c.Id.ToString(),
                Text = c.Name
            }
            ).ToList();

            return View(postViewModel);
        }

        [HttpPost]

        public async Task <IActionResult> Create (PostviewModel postviewModel)
        {

            if (ModelState.IsValid)
            {
                var inputFileExtension = Path.GetExtension(postviewModel.FeaturesImage.FileName).ToLower();
                bool isAllowed = _allowedExtension.Contains(inputFileExtension);
                if (!isAllowed)
                {
                    ModelState.AddModelError("Image", "Invalid image format. Allowed formats are .jpg, .jpeg, .png");
                    return View(postviewModel);
                }
                postviewModel.post.FeaturesImagePath = await UploadFileToFolder(postviewModel.FeaturesImage);
                _context.Posts.Add(postviewModel.post);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            postviewModel.Categories = _context.Categories.Select(c =>
           new SelectListItem
           {

               Value = c.Id.ToString(),
               Text = c.Name
           }
           ).ToList();


            return View(postviewModel);
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index(int? categoryId)
        {
            var postQuery = _context.Posts.Include(p => p.Category).AsQueryable();
            if (categoryId.HasValue)
            {
                postQuery = postQuery.Where(p => p.CategoryId == categoryId);
            }
            var posts = postQuery.ToList();

            ViewData["Categories"] = _context.Categories.ToList();

            return View(posts);
        }



        private async Task<string> UploadFileToFolder(IFormFile file)
        {
            var inputFileExtension = Path.GetExtension(file.FileName);
            var fileName = Guid.NewGuid().ToString() + inputFileExtension;
            var wwwRootPath = _webHostEnvironment.WebRootPath;
            var imagesFolderPath = Path.Combine(wwwRootPath, "images");

            if (!Directory.Exists(imagesFolderPath))
            {
                Directory.CreateDirectory(imagesFolderPath);
            }

            var filePath = Path.Combine(imagesFolderPath, fileName);

            try
            {
                await using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
            }
            catch (Exception ex)
            {
                // Log the exception if needed.
                return "Error Uploading Image: " + ex.Message;
            }

            return "/images/" + fileName;
        }
    }
}
