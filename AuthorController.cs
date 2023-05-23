using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;



namespace AspNetCoreDemo.Controllers
{
    public class AuthorController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Details(int id)
        {
            return View();
        }
        public ActionResult Create(int id)
        {
            return View();
        }
    }
}

