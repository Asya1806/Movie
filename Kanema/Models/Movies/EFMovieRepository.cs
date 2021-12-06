//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Kanema.Models.Movie
//{
//    public class EFMovieRepository : IRepository
//    {
//        public IEnumerable<Movie> Movies => throw new NotImplementedException();

//        public Movie DeleteMovie(int movieId)
//        {
//            Movie dbEntry = context.Movies.Find(movieId);
//            if (dbEntry != null)
//            {
//                context.Movies.Remove(dbEntry);
//                context.SaveChanges();            
//            }
//            return dbEntry;
//        }

//        public void SaveMovie(Movie movie)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
