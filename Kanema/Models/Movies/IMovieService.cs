using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kanema.Models.Movies
{
    public interface IMovieService
    {
        bool AddMovie(Movie movie);

        bool CreateMovie(string name, int year, string country, string producer, string genre, string annotation, string img, int categoryId);

        IEnumerable<Category> GetAllCategories();

        IEnumerable<Movie> GetAllMovies();

        bool RemoveMovie(Movie movie);

        bool TryShowMovie(int id, out Movie movie);

        bool ChangeMovie(Movie movie);

        //Task AddFavorite(FavoriteRequestModel favoriteRequest);
    }
}
