using AdminPanelCRUD.Helpers;
using AdminPanelCRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace AdminPanelCRUD.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class BookController : Controller
    {
        private readonly PustokContext _pustokContext;
        private readonly IWebHostEnvironment _env;
        public BookController(PustokContext pustokContext, IWebHostEnvironment env)
        {
            _pustokContext = pustokContext;
            _env = env;
        }
        public IActionResult Index()
        {
            List<Book> books = _pustokContext.Books.Include(x => x.Author).Include(x => x.Genre).Include(x => x.BookImages).ToList();
            ViewBag.Authors = _pustokContext.Authors.ToList();
            ViewBag.Genres = _pustokContext.Genres.ToList();
            return View(books);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Authors = _pustokContext.Authors.ToList();
            ViewBag.Genres = _pustokContext.Genres.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Book book)
        {
            ViewBag.Authors = _pustokContext.Authors.ToList();
            ViewBag.Genres = _pustokContext.Genres.ToList();
            if (!ModelState.IsValid) return View(book);
            if (book.PosterImgFile != null)
            {
                if (book.PosterImgFile.ContentType != "image/png" && book.PosterImgFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("PosterImgFile", "Ancaq png ve ya jpeg (jpg) formatinda olan sekilleri yukleye bilersiniz!");
                    return View();
                }
                if (book.PosterImgFile.Length > 3145728)
                {
                    ModelState.AddModelError("PosterImgFile", "Seklin olcusu 3mb-den cox ola bilmez!");
                    return View();
                }
                BookImages bookImage = new BookImages
                {
                    Book = book,
                    Image = FileManager.SaveFile(_env.WebRootPath, "uploads/books", book.PosterImgFile),
                    IsPoster = true
                };
                _pustokContext.BookImages.Add(bookImage);
            }
            else
            {
                ModelState.AddModelError("PosterImgFile", "Sekil bos ola bilmez");
                return View(book);
            }
            if (book.HoverImgFile != null)
            {
                if (book.HoverImgFile.ContentType != "image/png" && book.HoverImgFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("HoverImgFile", "Ancaq png ve ya jpeg (jpg) formatinda olan sekilleri yukleye bilersiniz!");
                    return View();
                }
                if (book.HoverImgFile.Length > 3145728)
                {
                    ModelState.AddModelError("HoverImgFile", "Seklin olcusu 3mb-den cox ola bilmez!");
                    return View();
                }
                BookImages bookImage = new BookImages
                {
                    Book = book,
                    Image = FileManager.SaveFile(_env.WebRootPath, "uploads/books", book.HoverImgFile),
                    IsPoster = false
                };
                _pustokContext.BookImages.Add(bookImage);
            }
            else
            {
                ModelState.AddModelError("HoverImgFile", "Sekil bos ola bilmez");
                return View(book);
            }
            if (book.ImageFiles != null)
            {
                foreach (IFormFile imageFile in book.ImageFiles)
                {
                    if (imageFile.ContentType != "image/png" && imageFile.ContentType != "image/jpeg")
                    {
                        ModelState.AddModelError("ImageFiles", "Ancaq png ve ya jpeg (jpg) formatinda olan sekilleri yukleye bilersiniz!");
                        return View();
                    }
                    if (imageFile.Length > 3145728)
                    {
                        ModelState.AddModelError("ImageFiles", "Seklin olcusu 3mb-den cox ola bilmez!");
                        return View();
                    }
                    BookImages bookImage = new BookImages
                    {
                        Book = book,
                        Image = FileManager.SaveFile(_env.WebRootPath, "uploads/books", imageFile),
                        IsPoster = null
                    };
                    _pustokContext.BookImages.Add(bookImage);
                }
            }
            else
            {
                ModelState.AddModelError("ImageFiles", "Sekil bos ola bilmez");
                return View(book);
            }
            _pustokContext.Books.Add(book);
            _pustokContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Book book = _pustokContext.Books
                .Include(x => x.BookImages)
                .FirstOrDefault(x => x.Id == id);
            if (book == null) View("Error");
            ViewBag.Authors = _pustokContext.Authors.ToList();
            ViewBag.Genres = _pustokContext.Genres.ToList();
            return View(book);
        }
        [HttpPost]
        public IActionResult Update(Book book)
        {
            ViewBag.Authors = _pustokContext.Authors.ToList();
            ViewBag.Genres = _pustokContext.Genres.ToList();
            Book existbook = _pustokContext.Books.
                Include(x => x.BookImages).
                FirstOrDefault(x => x.Id == book.Id);
            if (existbook == null) View("Error");
            if (!ModelState.IsValid) return View(existbook);

            existbook.BookImages.RemoveAll(x => !book.BookImageIds.Contains(x.Id) && x.IsPoster == null);

            if (book.PosterImgFile != null)
            {
                if (book.PosterImgFile.ContentType != "image/png" && book.PosterImgFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("ImageFiles", "Ancaq png ve ya jpeg (jpg) formatinda olan sekilleri yukleye bilersiniz!");
                    return View();
                }
                if (book.PosterImgFile.Length > 3145728)
                {
                    ModelState.AddModelError("ImageFiles", "Seklin olcusu 3mb-den cox ola bilmez!");
                    return View();
                }

                FileManager.DeleteFile(_env.WebRootPath, "uploads/books", existbook.BookImages.FirstOrDefault(x => x.IsPoster == true).Image);
                BookImages bookImage = new BookImages
                {
                    BookId = book.Id,
                    Image = FileManager.SaveFile(_env.WebRootPath, "uploads/books", book.PosterImgFile),
                    IsPoster = true
                };

                existbook.BookImages.FirstOrDefault(x => x.IsPoster == true).Image = bookImage.Image;

            }

            if (book.HoverImgFile != null)
            {
                if (book.HoverImgFile.ContentType != "image/png" && book.HoverImgFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("ImageFiles", "Ancaq png ve ya jpeg (jpg) formatinda olan sekilleri yukleye bilersiniz!");
                    return View();
                }
                if (book.HoverImgFile.Length > 3145728)
                {
                    ModelState.AddModelError("ImageFiles", "Seklin olcusu 3mb-den cox ola bilmez!");
                    return View();
                }

                FileManager.DeleteFile(_env.WebRootPath, "uploads/books", existbook.BookImages.FirstOrDefault(x => x.IsPoster == false).Image);

                BookImages bookImage = new BookImages
                {
                    BookId = book.Id,
                    Image = FileManager.SaveFile(_env.WebRootPath, "uploads/books", book.HoverImgFile),
                    IsPoster = false
                };
                existbook.BookImages.FirstOrDefault(x => x.IsPoster == false).Image = bookImage.Image;
            }
            if (book.ImageFiles != null)
            {
                foreach (var imageFile in book.ImageFiles)
                {
                    FileManager.DeleteFile(_env.WebRootPath, "uploads/books", existbook.BookImages.FirstOrDefault(x => x.IsPoster == null).Image);
                    if (imageFile.ContentType != "image/png" && imageFile.ContentType != "image/jpeg")
                    {
                        ModelState.AddModelError("ImageFiles", "Ancaq png ve ya jpeg (jpg) formatinda olan sekilleri yukleye bilersiniz!");
                        return View();
                    }
                    if (imageFile.Length > 3145728)
                    {
                        ModelState.AddModelError("ImageFiles", "Seklin olcusu 3mb-den cox ola bilmez!");
                        return View();
                    }
                    BookImages bookImage = new BookImages
                    {
                        Book = book,
                        Image = FileManager.SaveFile(_env.WebRootPath, "uploads/books", imageFile),
                        IsPoster = null
                    };
                    existbook.BookImages.Add(bookImage);
                }
            }
            existbook.AuthorId = book.AuthorId;
            existbook.GenreId = book.GenreId;
            existbook.Name = book.Name;
            existbook.Description = book.Description;
            existbook.Detail = book.Detail;
            existbook.Code = book.Code;
            existbook.IsAvaible = book.IsAvaible;
            existbook.IsFeatured = book.IsFeatured;
            existbook.IsNew = book.IsNew;
            existbook.CostPrice = book.CostPrice;
            existbook.SalePrice = book.SalePrice;
            existbook.Discount = book.Discount;
            _pustokContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Book book = _pustokContext.Books.Include(x=>x.BookImages).FirstOrDefault(x=>x.Id==id);
            if (book == null) NotFound(); //404

            if (book.BookImages != null)
            {
               foreach(var bookImage in book.BookImages)
                {
					FileManager.DeleteFile(_env.WebRootPath, "uploads/books", bookImage.Image);
				}
            }

            _pustokContext.Books.Remove(book);
            _pustokContext.SaveChanges();
            return Ok(); //200
        }

    }
}
