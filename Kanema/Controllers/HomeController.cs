using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Kanema.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Kanema.Models.Users;

namespace Kanema.Controllers
{
    public class HomeController : Controller
    {
        private UserContext _userContext;
        // IRepository repo;
        private IUserService _userService;

        public HomeController(IUserService userService)//UserContext userContext)
        {
            //_userContext = userContext ?? throw new ArgumentNullException(nameof(userContext));
            //repo = repository;
            _userService = userService;
        }

        [Authorize(Policy = "AgeLimit")]
        public IActionResult Index() => View();
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        //MovieContext db;
        //public HomeController(MovieContext context)
        //{
        //    db = context;
        //}
        //public IActionResult Index()
        //{
        //    return View(db.Movies.ToList());
        //}

        //[AcceptVerbs("Get", "Post")]
        //public IActionResult CheckLogin (string login)
        //{
        //    if (login == "admin.ru" || login == "aaa@mail.com")
        //        return Json(false);
        //    return Json(true);
        //}

        //[HttpGet]
        //public IActionResult RememberFilm (int? id)
        //{
        //    if (id == null) return RedirectToAction("Index");
        //    ViewBag.PhoneId = id;
        //    return View();
        //}
        //[HttpPost]
        //public string RememberFilm(User user)
        //{
        //    db.User.Add(user);
        //    // сохраняем в бд все изменения
        //    db.SaveChanges();
        //    return "Спасибо, " + user.User + ", что добавили фильм!";
        //}
        [Authorize(Roles = "admin")]
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return Content("For all ages");
        }
        //Теперь к методу Index смогут обратиться только те,
        //кто удовлетворяет ограничению AgeLimit
        //(в данном случае кому исполнилось 18 лет),
        //в то время как к методу About смогут обратиться все желающие.

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                User user = await _userContext.Users.FirstOrDefaultAsync(p => p.Id == id);
                if (user != null)
                    return View(user);
            }
            return NotFound();
        }

        public IActionResult EditUser(int? id)
        {
            if (id != null)
            {
                User user = _userService.Edit(id.Value);
                if (user != null)
                    return View(user);
            }
            return NotFound();
            
        }

        [HttpPost]
        public IActionResult AddUser(User user)
        {
            if (ModelState.IsValid)
            {
                _userService.Create(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        public IActionResult GetUser(int? id)
        {
            if (!id.HasValue)
                return BadRequest();
            User user = _userService.Get(id.Value);
            if (user == null)
                return NotFound();
            return View(user);
        }


    }
}
