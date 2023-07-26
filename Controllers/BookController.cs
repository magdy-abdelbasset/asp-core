using System.Net.Mime;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreDemo.Models;
using AspNetCoreDemo.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using AspNetCoreDemo.ViewModels;
using System.IO;

namespace firstwebapp.Controllers
{
    // [Route("[controller]")]
    public class BookController : Controller
    {
        // private IBookStoreRepostry<Book> bookRepository;
        // 
        // private readonly IServiceCollection<BookController> _logger;
        // public IBookStoreRepostry<Book> BookRepositry { get; }
        private readonly IBookstoreRepository<Book> bookRepository;
        private readonly IBookstoreRepository<Author> authorRepository;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment hosting;
        public BookController(IBookstoreRepository<Book> bookRepository,
            IBookstoreRepository<Author> authorRepository,
            Microsoft.AspNetCore.Hosting.IHostingEnvironment hosting)
        {
            this.bookRepository = bookRepository;
            this.authorRepository = authorRepository;
            this.hosting = hosting;
        }
        // [HttpGet]   // GET /api/test2

        public IActionResult Index()
        {
            var books = this.bookRepository.List();
            return View(books);
        }
        public IActionResult Details(int id)
        {
            var book = this.bookRepository.Find(id);
            return View(book);
        }
        public IActionResult Create()
        {
            var model = new BookAuthorViewModel
            {
                Authors = FillSelectList()
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BookAuthorViewModel model)
        {
            try
            {
                string fileName = this.UploadFile(model.File, model.ImageUrl);

                    if (model.AuthorId == -1)
                    {
                        ViewBag.Message = "Please select an author from the list!";

                        // return View(GetAllAuthors());
                    }

                    var author = authorRepository.Find(model.AuthorId);
                    Book book = new Book
                    {
                        Id = model.BookId,
                        Title = model.Title,
                        Description = model.Description,
                        Author = author,
                        ImageUrl = fileName
                    };

                    bookRepository.Add(book);
                return RedirectToAction(nameof(Index));
            }
            catch (System.Exception)
            {

                return View(new BookAuthorViewModel
            {
                Authors = FillSelectList()
            });
            }
        }
        public IActionResult Edit(int Id)
        {
            var book = bookRepository.Find(Id);
            var authorId = book.Author == null ? book.Author.Id = 0 : book.Author.Id;

            var model = new BookAuthorViewModel
            {
                BookId = book.Id,
                Title = book.Title,
                Description = book.Description,
                AuthorId = authorId,
                Authors = authorRepository.List().ToList(),
                ImageUrl = book.ImageUrl
            };
            return View(model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int Id, Book book)
        {
            try
            {
                bookRepository.Update(Id, book);
                return RedirectToAction(nameof(Index));
            }
            catch (System.Exception)
            {

                return View();
            }
        }
        public IActionResult Delete(int Id)
        {
            var book = bookRepository.Find(Id);
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int Id, IFormCollection collection)

        {
            try
            {
                bookRepository.Delete(Id);
                return RedirectToAction(nameof(Index));
            }
            catch (System.Exception)
            {

                return View();
            }
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
        List<Author> FillSelectList()
        {
            var authors = authorRepository.List().ToList();
            authors.Insert(0, new Author { Id = -1, FullName = "--- Please select an author ---" });

            return authors;
        }
    
    private string UploadFile(IFormFile file, string? imageUrl){
            if (file != null)
            {
                string uploads = Path.Combine(hosting.WebRootPath, "uploads");

                string newPath = Path.Combine(uploads, file.FileName);
                string oldPath = string.Empty;
                if(imageUrl != null){

                    oldPath = Path.Combine(uploads, imageUrl);
                }    

                if (oldPath != newPath)
                {
                    if(imageUrl != null){

                    System.IO.File.Delete(oldPath);
                    }
                    file.CopyTo(new FileStream(newPath, FileMode.Create));
                }

                return file.FileName;
            }

            return imageUrl;
        }
    }
}