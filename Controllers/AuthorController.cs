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

namespace firstwebapp.Controllers
{
    // [Route("[controller]")]
    public class AuthorController : Controller
    {
        // private IBookStoreRepostry<Author> authorRepository;
// 
        // private readonly IServiceCollection<AuthorController> _logger;
        // public IBookStoreRepostry<Author> AuthorRepositry { get; }
        private readonly IBookstoreRepository<Author> authorRepository;

        public AuthorController(IBookstoreRepository<Author> authorRepository)
        {
            this.authorRepository = authorRepository;
            
            // _logger = logger;
        }
        // [HttpGet]   // GET /api/test2

        public IActionResult Index()
        {
            var authors = this.authorRepository.List();
            return View(authors);
        }
        public IActionResult Details()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch (System.Exception)
            {

                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int Id)
        {
            return View();
        }
        public IActionResult Edit(int Id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch (System.Exception)
            {

                return View();
            }
        }
        public IActionResult Delete(int Id)
        {
            return View();
        }
        public IActionResult Delete(int Id, IFormCollection collection)

        {
            try
            {
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
    }
}