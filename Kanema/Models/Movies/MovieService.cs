using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kanema.Models.Movies
{
    public class MovieService : IMovieService
    {
        private MovieContext _movieContext;
        //private DbContextOptions options;

        public MovieService(MovieContext movieContext)
        {
            _movieContext = movieContext ?? throw new ArgumentNullException(nameof(_movieContext));
        }

        public bool AddMovie(Movie movie)
        {
            if (movie is null)
            {
                throw new ArgumentNullException(nameof(movie));
            }
            if (_movieContext.Movies.Contains(movie))
            {
                return false;
            }
            _movieContext.Add(movie);
            _movieContext.SaveChanges();
            return true;            
        }

        public bool CreateMovie(string name, int year, string country, string producer, string genre, string annotation, string img, int categoryId)
        {
            if (_movieContext.Movies.Where(m => m.Name == name).Count() != 0)
            {
                return false;
            }

            var movie = new Movie()
            {
                Name = name,
                Year = year,
                Country = country,
                Producer = producer,
                Genre = genre,
                Annotation = annotation,
                Img = img,
                CategoryId = categoryId,
            };
            _movieContext.Movies.Add(movie);
            return _movieContext.SaveChanges() == 1;
        }

        public IEnumerable<Movie> GetAllMovies() => _movieContext.Movies;

        public bool RemoveMovie(Movie movie)
        {
            if (_movieContext.Movies.Contains(movie))
            {
                _movieContext.Remove(movie);
                _movieContext.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<Category> GetAllCategories() => _movieContext.Categories.ToList();

        public bool TryShowMovie(int id, out Movie movie)
        {
            movie = _movieContext.Movies.Where(x => x.Id == id).FirstOrDefault();

            return !(movie is null);
        }

        public bool ChangeMovie(Movie movie)
        {
            if (movie is null)
            {
                return false;
            }

            var movieToUpdate = _movieContext.Movies.Where(x => x.Id == movie.Id).FirstOrDefault();

            if (movieToUpdate is null)
            {
                return false;
            }

            movieToUpdate.Name = movie.Name;
            movieToUpdate.Year = movie.Year;
            movieToUpdate.Country = movie.Country;
            movieToUpdate.Producer = movie.Producer;
            movieToUpdate.Genre = movie.Genre;
            movieToUpdate.Annotation = movie.Annotation;
            movieToUpdate.Img = movie.Img;
            movieToUpdate.Category = movie.Category;

            return _movieContext.SaveChanges() == 1;
        }


    }
}
