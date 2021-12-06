using Kanema.Models;
using Kanema.Models.Bookmarks;
using Kanema.Models.Cart;
using Kanema.Models.Movies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Kanema.Controllers
{
    public class MoviesController : Controller
    {
        private const long BYTES_OF_10_MB = 10485760;
        private IMovieService _movieService;
        private IWebHostEnvironment _appEnvironment;

        public MoviesController(IWebHostEnvironment appEnvironment, IMovieService movieService)
        {
            _appEnvironment = appEnvironment ?? throw new ArgumentNullException(nameof(appEnvironment));
            _movieService = movieService ?? throw new ArgumentNullException(nameof(MovieService));
        }

        [HttpGet]
        public ActionResult Index(int? id)
        {
            if (id is null)
            {
                return View();
            }

            if (_movieService.TryShowMovie((int)id, out Movie movie))
            {
                return View("Movie", movie);
            }

            return Redirect("/Movies");
        }

        [HttpPost]
        public ActionResult Search(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return PartialView(_movieService.GetAllMovies());
            }

            name = name.ToUpper();

            return PartialView(_movieService.GetAllMovies().Where(movie => movie.Name.ToUpper().Contains(name)));
        }

        [HttpGet]
       // [Authorize(Roles = "admin")]
        
        //[ValidateAntiForgeryToken]
        public ActionResult Create()
        {
            ViewBag.Categories = _movieService.GetAllCategories();
            // var a = User.Claims;
            if (User.IsInRole("admin"))
            {
                return View();
            }
            return View();


        }

        [HttpPost]
        //[Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MovieModel model)
        {
            ViewBag.Categories = _movieService.GetAllCategories();
            if (User.IsInRole("admin"))
            {   
                var movie = new Movie() { Name = model.Name };

                if (model.Img is null)
                {
                    ModelState.AddModelError("", "Не выбрана картинка фильма.");
                    return View();
                }
                else if (model.Img.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("", "Выбран некорректный тип данных.");
                    return View();
                }
                else if (model.Img.Length > BYTES_OF_10_MB)
                {
                    ModelState.AddModelError("", "Файл весит слишком много.");
                    return View();
                }
                else
                {
                    string img = model.Img.FileName;
                    string path = Path.Combine(_appEnvironment.WebRootPath, img);

                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await model.Img.CopyToAsync(fileStream);

                        if (!_movieService.CreateMovie(model.Name, model.Year, model.Country, model.Producer, model.Genre, model.Annotation, img, model.Category))
                        {
                            ModelState.AddModelError("", "Невозможно создать новый фильм.");
                            return View();
                        }
                    }
                }

                return Redirect($"/Movies?id={_movieService.GetAllMovies().Last().Id}");
        }
            return Redirect($"/Movies?id={_movieService.GetAllMovies().Last().Id}");

    }

        [HttpGet]
        //[Authorize(Roles = "admin")]
      //  [Route("Change/{id}")]
        public ActionResult Change(int id)
        {
            if (User.IsInRole("admin"))
            {
                _movieService.TryShowMovie(id, out Movie movie);
                return View(movie);
            }
            return View();
        }

        [HttpPost]
      //  [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Change(Movie model)
        {
            if (User.IsInRole("admin"))
            {
                _movieService.ChangeMovie(model);

                return Redirect($"/Movies?id={_movieService.GetAllMovies().Last().Id}");
            }
            return Redirect($"/Movies?id={_movieService.GetAllMovies().Last().Id}");

        }

        [HttpGet]
        //[Authorize(Roles = "admin")]
        [Route("Change/{id}")]
        public ActionResult DeleteMovie(int id)
        {
            if (User.IsInRole("admin"))
            {
                _movieService.TryShowMovie(id, out Movie movie);
                return View(movie);
            }
            return View();
        }

        [HttpPost]
        //  [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteMovie(Movie model)
        {
            if (User.IsInRole("admin"))
            {
                _movieService.RemoveMovie(model);

                return Redirect($"/Movies?id={_movieService.GetAllMovies().Last().Id}");
            }
            return Redirect($"/Movies?id={_movieService.GetAllMovies().Last().Id}");

        }

        private const string sessionKey = "Bookmark";

        //private IMovieService _movieService;
        // private IRepository _repository;


        [HttpPost]
        public IActionResult RemoveMovieFromBookmark(int id, string returnUrl)
        {
            var bookmark = HttpContext.Session.Get<BookmarkCountMovie>(sessionKey) ?? new BookmarkCountMovie();

            if (_movieService.TryShowMovie(id, out Movie movie))
            {
                var cartline = bookmark.ListBookmarks.Where(x => x.Movie.Equals(movie)).FirstOrDefault();
                if (cartline != null)
                {
                    bookmark.ListBookmarks.Remove(cartline);
                }
            }

            HttpContext.Session.Set<BookmarkCountMovie>("Bookmark", bookmark);

            return Redirect(returnUrl);
        }

        [HttpPost]
        public IActionResult AddMovieToBookmark(int id, string returnUrl)
        {

            var bookmark = HttpContext.Session.Get<BookmarkCountMovie>(sessionKey) ?? new BookmarkCountMovie();

            if (_movieService.TryShowMovie(id, out Movie movie))
            {
                var cartline = bookmark.ListBookmarks.Where(x => x.Movie.Equals(movie)).FirstOrDefault();
                if (cartline is null)
                {
                    bookmark.ListBookmarks.Add(new Bookmark() { Movie = movie, Quantity = 1 });
                }
                else
                {
                    bookmark.ListBookmarks.Remove(cartline);

                    cartline.Quantity++;
                    bookmark.ListBookmarks.Add(cartline);
                }
            }

            HttpContext.Session.Set<BookmarkCountMovie>(sessionKey, bookmark);

            return Redirect(returnUrl);
        }

        [HttpPost]
        public IActionResult RemoveMovie(int id, string returnUrl)
        {
            var cart = HttpContext.Session.Get<Cart>(sessionKey) ?? new Cart();

            if (_movieService.TryShowMovie(id, out Movie movie))
            {
                var cartline = cart.CartLines.Where(x => x.Movie.Equals(movie)).FirstOrDefault();
                if (cartline != null)
                {
                    cart.CartLines.Remove(cartline);
                }
            }

            HttpContext.Session.Set<Cart>("Cart", cart);

            return Redirect(returnUrl);
        }
    }
}
