using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kanema.Models.Movies
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public List<Movie> Movies{ get; set; }//какие фильмы входят в эту категорию
        
        public Category()
        {
            Movies = new List<Movie>();
        }
    }
}
