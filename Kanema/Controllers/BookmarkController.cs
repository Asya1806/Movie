using Kanema.Models;
using Kanema.Models.Movies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Kanema.Models.Cart;

namespace Kanema.Controllers
{
    [Authorize]
    public class BookmarkController : Controller
    {
        private const string sessionKey = "Cart";

        private IMovieService _movieService;
        private IRepository _repository;

        public BookmarkController(IMovieService movieService, IRepository repository)
        {
            _movieService = movieService;
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            //return View(HttpContext.Session.Get<Cart>("Cart"));
            return View();// HttpContext.Session.Get<Cart>("Cart") ?? new Cart());
        }

        //public bool AddMovieToBookmark(string name, int year, string country, string producer, string genre, string annotation, string img, int categoryId)
        //{
        //    if (_movieContext.Movies.Where(m => m.Name == name).Count() != 0)
        //    {
        //        return false;
        //    }

        //    var movie = new Movie()
        //    {
        //        Name = name,
        //        Year = year,
        //        Country = country,
        //        Producer = producer,
        //        Genre = genre,
        //        Annotation = annotation,
        //        Img = img,
        //        CategoryId = categoryId,
        //    };
        //    _movieContext.Movies.Add(movie);
        //    return _movieContext.SaveChanges() == 1;
        //}


        //[HttpPost]
        //public IActionResult AddMovieToBookmark(int id, string returnUrl)
        //{

        //    var cart = HttpContext.Session.Get<Cart>(sessionKey) ?? new Cart();

        //    if (_movieService.TryShowMovie(id, out Movie movie))
        //    {
        //        var cartline = cart.CartLines.Where(x => x.Movie.Equals(movie)).FirstOrDefault();
        //        if (cartline is null)
        //        {
        //            cart.CartLines.Add(new CartLine() { Movie = movie, Quantity = 1 });
        //        }
        //        else
        //        {
        //            cart.CartLines.Remove(cartline);

        //            cartline.Quantity++;
        //            cart.CartLines.Add(cartline);
        //        }
        //    }

        //    HttpContext.Session.Set<Cart>(sessionKey, cart);

        //    return Redirect(returnUrl);
        //}

        //[HttpPost]
        //public IActionResult RemoveMovieFromCart(int id, string returnUrl)
        //{
        //    var cart = HttpContext.Session.Get<Cart>(sessionKey) ?? new Cart();

        //    if (_movieService.TryShowMovie(id, out Movie movie))
        //    {
        //        var cartline = cart.CartLines.Where(x => x.Movie.Equals(movie)).FirstOrDefault();
        //        if (cartline != null)
        //        {
        //            cart.CartLines.Remove(cartline);
        //        }
        //    }

        //    HttpContext.Session.Set<Cart>("Cart", cart);

        //    return Redirect(returnUrl);
        //}

        // GET: CartController


        //********************************************************************************************************************************************************************************

        //public RedirectToActionResult AddToCart(CartTwo cart, int movieId, string returnUrl) // ??? RedirectToRouteResult 
        //{
        //    //var cart = HttpContext.Session.Get<Cart>(sessionKey) ?? new Cart();
        //    MovieController movie = _repository.Movies.FirstOrDefault(m => m.Id == movieId);

        //    if (movie != null)
        //    {
        //        cart.AddItem(movie, 1);
        //    }

        //    return RedirectToAction("Index", new { returnUrl });
        //}

        //public RedirectToActionResult RemoveFromCart(CartTwo cart, int movieId, string returnUrl)// ??? RedirectToRouteResult 
        //{
        //    MovieController movie = _repository.Movies.FirstOrDefault(m => m.Id == movieId);

        //    if (movie != null)
        //    {
        //        cart.RemoveLine(movie);
        //    }
        //    return RedirectToAction("Index", new { returnUrl });
        //}

        //public Cart GetCart()
        //{
        //    Cart cart = (Cart)Session["Cart"];
        //    if (cart == null)
        //    {
        //        cart = new Cart();
        //        Session["Cart"] = cart;
        //    }
        //    return cart;
        //}



        //// GET: CartController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: CartController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: CartController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: CartController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: CartController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: CartController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: CartController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
