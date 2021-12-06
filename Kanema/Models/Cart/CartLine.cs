using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kanema.Models.Movies;

namespace Kanema.Models.Cart
{
    public class CartLine
    {
        public Movie Movie { get; set; }
        public int Quantity { get; set; }
    }
}
