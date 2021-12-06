using Kanema.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kanema.Models.Movies
{
    public class RememberMovie
    {
        /// <summary>
        /// Id фильма
        /// </summary>
        public int RememberMovieId { get; set; }

        /// <summary>
        /// Пользователь
        /// </summary>
        public User User { get; set; }

        //public int? CategoryId { get; set; }

        //public virtual Category Category { get; set; }    


        public int MovieId { get; set; }

        public Movie Movie { get; set; }
    }
}
