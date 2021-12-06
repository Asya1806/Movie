using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kanema.Models.Movies
{
    public interface IRepository
    {
        IEnumerable<Movie> Movies { get; }

        void SaveMovie(Movie movie);

        Movie DeleteMovie(int movieId);

        //Task Edit(int? id);
    }
}
