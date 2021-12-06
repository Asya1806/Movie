//using Kanema.Models;
//using Kanema.Models.Users;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Http.Extensions;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Kanema.Controllers
//{
//    public class UserController : Controller
//    {

//        private readonly IUserService _userService;

//        public UserController(IUserService userService)
//        {
//            _userService = userService;
//        }

//        //[Authorize]
//        //[HttpPost]
//        //public async Task<ActionResult> Favorite(FavoriteRequestModel favoriteRequest)
//        //{
//        //    string url = HttpContext.Request.GetDisplayUrl();
//        //    await _userService.AddFavorite(favoriteRequest);
//        //    return View();
//        //}
//        //[HttpGet]
//        //[Route("User/{id}/movie/{movieId}")]
//        //public async Task<ActionResult> Favorite(int id, int movieId)
//        //{
//        //    bool isMyFav = await _userService.IsMovieFavorited(id, movieId);
//        //    return View(isMyFav);

//        //}
//        //[Authorize]
//        //[HttpPost]
//        //public async Task<ActionResult> DeleteFavorite(FavoriteRequestModel favoriteRequestModel)
//        //{
//        //    await _userService.RemoveFavorite(favoriteRequestModel);
//        //    return View();
//        //}

//        /// <summary>
//        /// //////////////////////////////////////////
//        /// </summary>
//        /// <param name="favoriteRequest"></param>
//        /// <returns></returns>

//        //[Authorize]
//        //[HttpPost("favorite")]
//        //public async Task<ActionResult> CreateFavorite([FromBody] FavoriteRequestModel favoriteRequest)
//        //{
//        //    await _userService.AddFavorite(favoriteRequest);
//        //    return Ok();
//        //}
//        //[Authorize]
//        //[HttpPost("unfavorite")]
//        //public async Task<ActionResult> DeleteFavorite([FromBody] FavoriteRequestModel favoriteRequest)
//        //{
//        //    await _userService.RemoveFavorite(favoriteRequest);
//        //    return Ok();
//        //}
//        ////[Authorize]
//        //[HttpGet("favorites/{id}")]
//        //public async Task<ActionResult> AllFavorite(int id)
//        //{
//        //    var favorites = await _userService.GetAllFavoritesByUser(id);
//        //    return Ok(favorites);
//        //}
//        //[Authorize]
//        //[HttpGet("{id:int}/movie/{movieId}/favorite")]
//        //public async Task<ActionResult> IsFavoriteExists(int id, int movieId)
//        //{
//        //    var favoriteExists = await _userService.IsMovieFavorited(id, movieId);
//        //    return Ok(new { isFavorited = favoriteExists });
//        //}

//        //// GET: UserController
//        //public ActionResult Index()
//        //{
//        //    return View();
//        //}

//        //// GET: UserController/Details/5
//        //public ActionResult Details(int id)
//        //{
//        //    return View();
//        //}

//        //// GET: UserController/Create
//        //public ActionResult Create()
//        //{
//        //    return View();
//        //}

//        //// POST: UserController/Create
//        //[HttpPost]
//        //[ValidateAntiForgeryToken]
//        //public ActionResult Create(IFormCollection collection)
//        //{
//        //    try
//        //    {
//        //        return RedirectToAction(nameof(Index));
//        //    }
//        //    catch
//        //    {
//        //        return View();
//        //    }
//        //}

//        //// GET: UserController/Edit/5
//        //public ActionResult Edit(int id)
//        //{
//        //    return View();
//        //}

//        //// POST: UserController/Edit/5
//        //[HttpPost]
//        //[ValidateAntiForgeryToken]
//        //public ActionResult Edit(int id, IFormCollection collection)
//        //{
//        //    try
//        //    {
//        //        return RedirectToAction(nameof(Index));
//        //    }
//        //    catch
//        //    {
//        //        return View();
//        //    }
//        //}

//        //// GET: UserController/Delete/5
//        //public ActionResult Delete(int id)
//        //{
//        //    return View();
//        //}

//        //// POST: UserController/Delete/5
//        //[HttpPost]
//        //[ValidateAntiForgeryToken]
//        //public ActionResult Delete(int id, IFormCollection collection)
//        //{
//        //    try
//        //    {
//        //        return RedirectToAction(nameof(Index));
//        //    }
//        //    catch
//        //    {
//        //        return View();
//        //    }
//        //}
//    }
//}
