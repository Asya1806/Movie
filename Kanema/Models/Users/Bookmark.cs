using Kanema.Models.Movies;
using Kanema.Models.Users;
using System;
using System.ComponentModel.DataAnnotations;

namespace Kanema.Models.Bookmarks
{//подключить закладку

    public class Bookmark
    {
        [Key]
        public int Id { get; set; }

        public int? UserId { get; set; }

        public User User { get; set; }

        public int? MovieId { get; set; }

        public Movie Movie { get; set; }

        public int Quantity { get; set; }
    }
}
