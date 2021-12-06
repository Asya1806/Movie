using Kanema.Models.Bookmarks;
using Kanema.Models.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kanema.Models.Users
{
    public interface IUserService
    {
        Task<User> GetUser(string login, string password);
        Task<bool> ContainsUser(string login);

      //  Task<Bookmark> GetMovieBookmark(Movie movie);
      //  Task<bool> ContainsMovie(Movie movie);
        ValueTask<Bookmark> TryGetBookmark(int? id);

        Task RegisterAdmin(string login, string password);
        Task RegisterUser(string login, string password);
        ValueTask<Role> TryGetRole(int? id);

        //IEnumerable<User> GetAll();
        User Details(int id);
        User Edit(int id);
        User Get(int id);

        
        void Create(User newUser);

        //Task AddFavorite(FavoriteRequestModel favoriteRequest);
        //Task<IEnumerable<Movie>> GetAllFavoritesByUser(int id);
        //Task<bool> IsMovieFavorited(int id, int movieId);
        //Task RemoveFavorite(FavoriteRequestModel favoriteRequest);
    }
}
