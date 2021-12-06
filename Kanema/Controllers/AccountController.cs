using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Kanema.Models; // пространство имен моделей RegisterModel и LoginModel
using Kanema.Models.Users; // пространство имен UserContext и класса User
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System;
using Kanema.Models.Bookmarks;
using Kanema.Models.Movies;
using System.Linq;

namespace Kanema.Controllers
{
    public class AccountController : Controller
    {
        private IUserService _userService;
        private AccountValidator _accountValidator;

        public AccountController(IUserService userService, AccountValidator accountValidator)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _accountValidator = accountValidator ?? throw new ArgumentNullException(nameof(accountValidator));
        }

        // GET: /Account/Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                if (!_accountValidator.VerifyData(model.Login, model.Password, model.ConfirmPassword))
                {
                    ModelState.AddModelError("", "Произошла ошибка сервера.");
                }
                else
                {
                    if (!await _userService.ContainsUser(model.Login))
                    {
                        await _userService.RegisterUser(model.Login, model.Password);

                        return RedirectToAction("Index", "Movies"); 
                    }
                    else
                    {
                        ModelState.AddModelError("", "Login claimed/");
                    }
                }
            }
            return View(model);
        }

        // POST: /Account/Register
        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Register(RegisterModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (!await _userService.ContainsUser(model.Login))
        //        {
        //            await _userService.RegisterUser(model.Login, model.Password);

        //            return RedirectToAction("Login", "Account");
        //        }
        //        else
        //            ModelState.AddModelError("", "Некорректные логин и(или) пароль");
        //    }
        //    return View(model);
        //}

        //// POST: /Account/Register
        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Register(RegisterModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        User user = await _accountService.Users.FirstOrDefaultAsync(u => u.Login == model.Login);
        //        if (user == null)
        //        {
        //            // добавляем пользователя в бд
        //            user = new User { Login = model.Login, Password = model.Password };
        //            Role userRole = await _context.Roles.FirstOrDefaultAsync(r => r.Name == "user");
        //            if (userRole != null)
        //                user.Role = userRole;

        //            _context.Users.Add(user);
        //            await _context.SaveChangesAsync();

        //            await Authenticate(user); // аутентификация

        //            return RedirectToAction("Index", "Home");
        //        }
        //        else
        //            ModelState.AddModelError("", "Некорректные логин и(или) пароль");
        //    }
        //    return View(model);
        //}

        // GET: /Account/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (!_accountValidator.VerifyLogin(model.Login))
                {
                }
                else if (!_accountValidator.VerifyPassword(model.Password))
                {
                }
                else
                {
                    User user = await _userService.GetUser(model.Login, model.Password);
                    //Bookmark bookmark = await _userService.GetMovieBookmark(Movie movie);

                    if (user != null)
                    {
                        user.Role = await _userService.TryGetRole(user.RoleId);
                       // user.Bookmark = await _userService.TryGetBookmark(user.BookmarkId);

                        await Authenticate(user); // аутентификация

                        if (string.IsNullOrEmpty(returnUrl))
                        {
                            returnUrl = "/";
                        }

                        return Redirect(returnUrl);
                        //return RedirectToAction("Index", "Movies");
                    }

                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
                }
            }
            else
            {
                int i = ModelState.ErrorCount;
                i++;
            }

            return View(model);
        }

        //// POST: /Account/Login
        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Login(LoginModel model, string returnUrl)
        //{
        //    if (ModelState.IsValid)
        //    {                
        //        if (!await _userService.ContainsUser(model.Login))
        //        {
        //            await _userService.RegisterUser(model.Login, model.Password);

        //            return RedirectToAction("Login", "Account");
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", "Login claimed/");
        //        }
        //        ModelState.AddModelError("", "Некорректные логин и(или) пароль");
        //    }           
        //    return View(model);
        //}

        private async Task Authenticate(User user)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.Name),
             //   new Claim(ClaimTypes.DateOfBirth, user.Year.ToString())
            };
            // создаем объект ClaimsIdentity
            var id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Movies");
        }

       // private const string sessionKey = "Bookmark";

       // private IMovieService _movieService;
       //// private IRepository _repository;


       // [HttpPost]
       // public IActionResult RemoveMovieFromBookmark(int id, string returnUrl)
       // {
       //     var bookmark = HttpContext.Session.Get<BookmarkCountMovie>(sessionKey) ?? new BookmarkCountMovie();

       //     if (_movieService.TryShowMovie(id, out Movie movie))
       //     {
       //         var cartline = bookmark.ListBookmarks.Where(x => x.Movie.Equals(movie)).FirstOrDefault();
       //         if (cartline != null)
       //         {
       //             bookmark.ListBookmarks.Remove(cartline);
       //         }
       //     }

       //     HttpContext.Session.Set<BookmarkCountMovie>("Bookmark", bookmark);

       //     return Redirect(returnUrl);
       // }

       // [HttpPost]
       // public IActionResult AddMovieToBookmark(int id, string returnUrl)
       // {

       //     var bookmark = HttpContext.Session.Get<BookmarkCountMovie>(sessionKey) ?? new BookmarkCountMovie();

       //     if (_movieService.TryShowMovie(id, out Movie movie))
       //     {
       //         var cartline = bookmark.ListBookmarks.Where(x => x.Movie.Equals(movie)).FirstOrDefault();
       //         if (cartline is null)
       //         {
       //             bookmark.ListBookmarks.Add(new Bookmark() { Movie = movie, Quantity = 1 });
       //         }
       //         else
       //         {
       //             bookmark.ListBookmarks.Remove(cartline);

       //             cartline.Quantity++;
       //             bookmark.ListBookmarks.Add(cartline);
       //         }
       //     }

       //     HttpContext.Session.Set<BookmarkCountMovie>(sessionKey, bookmark);

       //     return Redirect(returnUrl);
       // }
    }
}
