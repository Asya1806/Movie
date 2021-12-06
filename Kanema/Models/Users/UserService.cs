using Kanema.Models.Bookmarks;
using Kanema.Models.Movies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kanema.Models.Users
{
    public class UserService : IUserService
    {
        private UserContext _userContext;
        //private readonly IFavoriteRepository _favoriteRepository;
        //private readonly IUserRepository _userRepository;

        public UserService(UserContext userContext)//, IFavoriteRepository favoriteRepository, IUserRepository userRepository)
        {
            _userContext = userContext ?? throw new ArgumentNullException(nameof(userContext));
            //_favoriteRepository = favoriteRepository;
            //_userRepository = userRepository;
        }



        
        //проверка, есть ли в такой пользователь в бд
        public Task<bool> ContainsUser(string login)=>_userContext.Users.Select(x => x.Login).ContainsAsync(login);
       
        //получение пользователя из бд
        public Task<User> GetUser(string login, string password) => _userContext.Users.FirstOrDefaultAsync(user => user.Login == login && user.Password == password);

        public Task<User> GetUser(string login) => _userContext.Users.FirstOrDefaultAsync(user => user.Login == login);

        public async Task RegisterUser(string login, string password)
        {
            var user = new User() { Login = login, Password = password };
            var userRole = await _userContext.Roles.FirstOrDefaultAsync(r => r.Name == "user");

            if (userRole!= null)
            {
                user.Role = userRole;

                await _userContext.AddAsync(user);
                _userContext.Roles.Where(r => r.Id == 2).OrderBy(r => r.Id).FirstOrDefault().Users.Add(user);
                
                await _userContext.SaveChangesAsync();
            }
        }

        public async Task RegisterAdmin(string login, string password)
        {
            var user = new User() { Login = login, Password = password };
            var userRole = await _userContext.Roles.FirstOrDefaultAsync(r => r.Name == "admin");

            if (userRole != null)
            {
                user.Role = userRole;
                user.RoleId = userRole.Id;

                await _userContext.AddAsync(user);
                await _userContext.SaveChangesAsync();
            }

        }

        public ValueTask<Role> TryGetRole(int? id) => _userContext.Roles.FindAsync(id);


        /// /////////////////
        /// 

        //public async Task AddMovieToBookmark(string login, string password, int year)
        //{
        //    var user = new User() { Login = login, Password = password, Year = year };
        //    var userRole = await _userContext.Roles.FirstOrDefaultAsync(r => r.Name == "user");

        //    if (userRole != null)
        //    {
        //        user.Role = userRole;

        //        await _userContext.AddAsync(user);
        //        await _userContext.SaveChangesAsync();
        //    }
        //}

        //public Task<bool> ContainsMovie(Movie movie) => _userContext.Bookmarks.Select(x => x.Movie).ContainsAsync(movie);

        //public Task<Bookmark> GetMovieBookmark(Movie movie) => _userContext.Bookmarks.FirstOrDefaultAsync(bookmark => bookmark.Movie == movie);

        public ValueTask<Bookmark> TryGetBookmark(int? id) => _userContext.Bookmarks.FindAsync(id);

        public User Edit(int id)
        {
            throw new NotImplementedException();
        }

        public User Details(int id)
        {
            throw new NotImplementedException();
        }

        public User Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Create(User newUser)
        {
            throw new NotImplementedException();
        }

        //public async Task AddFavorite(FavoriteRequestModel favoriteRequest)
        //{
        //    var newFavorite = new Favorite
        //    {
        //        UserId = favoriteRequest.UserId,
        //        MovieId = favoriteRequest.MovieId
        //    };
        //    await _favoriteRepository.AddAsync(newFavorite);
        //}

        //public async Task RemoveFavorite(FavoriteRequestModel favoriteRequest)
        //{

        //    var dbFavorite = await _favoriteRepository.ListAsync(r => r.UserId == favoriteRequest.UserId &&
        //                                                 r.MovieId == favoriteRequest.MovieId);

        //    await _favoriteRepository.DeleteAsync(dbFavorite.First());
        //}

        //public async Task<bool> IsMovieFavorited(int userId, int movieId)
        //{
        //    return await _favoriteRepository.GetExistsAsync(f => f.MovieId == movieId &&
        //                                                         f.UserId == userId);
        //}
        //public async Task<IEnumerable<Movie>> GetAllFavoritesByUser(int id)
        //{
        //    return await _userRepository.GetAllFavoritesByUser(id);
        //}
    }
}
