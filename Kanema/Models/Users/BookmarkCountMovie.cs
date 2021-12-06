using Kanema.Models.Bookmarks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kanema.Models.Bookmarks
{
    public class BookmarkCountMovie
    {
        public BookmarkCountMovie()
        {
            ListBookmarks = new();
        }

        public BookmarkCountMovie(List<Bookmark> listBookmarks)
        {
            ListBookmarks = listBookmarks ?? throw new ArgumentException(nameof(listBookmarks));
        }

        public List<Bookmark> ListBookmarks { get; set; }
    }
}
