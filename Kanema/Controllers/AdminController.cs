//using Kanema.Models.Movies;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Kanema.Controllers
//{
//    public class AdminController : Controller
//    {
//        IRepository _repository;

//        public AdminController (IRepository repository)
//        {
//            _repository = repository;
//        }



//        public ViewResult Index()
//        {
//            return View(_repository.Movies);
//        }

//        [HttpPost]
//        public ActionResult Delete(int movieId)
//        {
//            MovieController deletedMovie = _repository.DeleteMovie(movieId);
//            if (deletedMovie != null)
//            {
//                TempData["message"] = string.Format("Фильм \"{0}\" был удален",
//                    deletedMovie.Name);
//            }
//            return RedirectToAction("Index");
//        }
//    }
//}
