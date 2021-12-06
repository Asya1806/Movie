using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kanema.Models.Movies;


namespace Kanema.Models.Cart
{
    public class Cart
    {
        public Cart()
        {
            CartLines = new();
        }

        public Cart(List<CartLine> cartLines)
        {
            cartLines = cartLines ?? throw new ArgumentException(nameof(cartLines));
        }

        public List<CartLine> CartLines { get; set; }
    }
}  