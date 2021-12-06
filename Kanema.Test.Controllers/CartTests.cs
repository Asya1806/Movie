using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kanema.Models;
using NUnit.Framework;
using Kanema.Models.Movies;
using Kanema.Models.Cart;

namespace Kanema.Test.Controllers
{
    [TestFixture]
    class CartTests
    {
        //[TestCase(1, "Movie1", 2002, "USA", "ewww", "Roman", "wwwwwwwwwwwwww", "#")]
        //[TestCase(2, "Movie2", 2002, "USA", "ewww", "Roman", "wwwwwwwwwwwwww", "#")]
        //public void AddItemToCartTest(int id, string name, int year, string country, string producer, string genry, string anotation, string img)
        //{
        //    var movie = new Movie()
        //    {
        //        Id = id,
        //        Name = name,
        //        Year = year,
        //        Country = country,
        //        Producer = producer,
        //        Genre = genry,
        //        Annotation = anotation,
        //        Img = img,
        //    };

        //    CartTwo cart = new CartTwo();
        //    List<CartLine> results = cart.Lines.ToList();

        //    cart.AddItem(movie, 1);

        //    Assert.IsTrue(cart.Lines.Where(x => x.Movie == movie).FirstOrDefault() != null);
        //    Assert.AreEqual(results[0].Movie, movie);
        //}


        //[TestCase(1, "Movie1", 2002, "USA", "ewww", "Roman", "wwwwwwwwwwwwww", "#############")]
        //[TestCase(2, "Movie2", 2002, "USA", "ewww", "Roman", "wwwwwwwwwwwwww", "#############")]
        //public void AddQuantityForExistingLinesTest(int id, string name, int year, string country, string producer, string genry, string anotation, string img)
        //{
        //    var movie = new Movie()
        //    {
        //        Id = id,
        //        Name = name,
        //        Year = year,
        //        Country = country,
        //        Producer = producer,
        //        Genre = genry,
        //        Annotation = anotation,
        //        Img = img,
        //    };

        //    Cart cart = new Cart();

        //    cart.AddItem(movie, 1);
        //    //cart.AddItem(movie, 1);
        //    cart.AddItem(movie, 5);
        //    List<CartLine> results = cart.Lines.OrderBy(c => c.Movie.Id).ToList();

        //   // Assert.IsTrue(cart.Lines.Where(x => x.Movie == movie).FirstOrDefault() != null);
        //    Assert.AreEqual(results.Count(), 2);
        //    Assert.AreEqual(results[0].Quantity, 6);
        //    Assert.AreEqual(results[1].Quantity, 1);
        //}

        [Test]
        public void AddQuantityForExistingLinesTest()
        {
            var movie1 = new Movie { Id = 1, Name = "Movie1", Year = 2002, Country = "USA", Producer = "ewww", Genre = "Roman", Annotation = "wwwwwwwwwwwwww", Img = "#############" };
            var movie2 = new Movie { Id = 2, Name = "Movie2", Year = 2002, Country = "USA", Producer = "ewww", Genre = "Roman", Annotation = "wwwwwwwwwwwwww", Img = "#############" };

            CartTwo cart = new CartTwo();

            cart.AddItem(movie1, 1);
            cart.AddItem(movie2, 1);
            cart.AddItem(movie1, 5);
            List<CartLine> results = cart.Lines.OrderBy(c => c.Movie.Id).ToList();

            Assert.AreEqual(results.Count(), 2);
            Assert.AreEqual(results[0].Quantity, 6);
            Assert.AreEqual(results[1].Quantity, 1);
        }

        //[TestCase(1, "Movie1", 2002, "USA", "ewww", "Roman", "wwwwwwwwwwwwww", "#############")]
        //[TestCase(2, "Movie2", 2002, "USA", "ewww", "Roman", "wwwwwwwwwwwwww", "#############")]
        //[TestCase(3, "Movie3", 2002, "USA", "ewww", "Roman", "wwwwwwwwwwwwww", "#############")]
        //[TestCase(2, "Movie2", 2002, "USA", "ewww", "Roman", "wwwwwwwwwwwwww", "#############")]
        //public void RemoveLineTest(int id, string name, int year, string country, string producer, string genry, string anotation, string img)
        //{
        //    var movie = new Movie()
        //    {
        //        Id = id,
        //        Name = name,
        //        Year = year,
        //        Country = country,
        //        Producer = producer,
        //        Genre = genry,
        //        Annotation = anotation,
        //        Img = img,
        //    };

        //    Cart cart = new Cart();

        //    cart.AddItem(movie, 1);
        //    //cart.AddItem(movie, 4);
        //    //cart.AddItem(movie, 2);
        //    //cart.AddItem(movie, 1);

        //    cart.RemoveLine(movie);

        //    Assert.AreEqual(cart.Lines.Where(c => c.Movie == movie).Count(), 0);
        //    Assert.AreEqual(cart.Lines.Count(), 2);

        //}

        [Test]
        public void RemoveLineTest()
        {
            var movie1 = new Movie { Id = 1, Name = "M", Year = 2002, Country = "USA", Producer = "ewww", Genre = "Roman", Annotation = "wwwwwwwwwwwwww", Img = "#############" };
            var movie2 = new Movie { Id = -2, Name = "Movie2", Year = 2002, Country = "USA", Producer = "ewww", Genre = "Roman", Annotation = "wwwwwwwwwwwwww", Img = "#############" };
            var movie3 = new Movie { Id = 3, Name = "Movie3", Year = 2002, Country = "USA", Producer = "ewww", Genre = "Roman", Annotation = "wwwwwwwwwwwwww", Img = "#############" };

            CartTwo cart = new CartTwo();

            cart.AddItem(movie1, 1);
            cart.AddItem(movie2, 4);
            cart.AddItem(movie3, 2);
            cart.AddItem(movie2, 1);

            cart.RemoveLine(movie2);

            Assert.AreEqual(cart.Lines.Where(c => c.Movie == movie2).Count(), 0);
            Assert.AreEqual(cart.Lines.Count(), 2);
        }

        [TestCase(-1, "Movie1", 2002, "USA", "ewww", "Roman", "wwwwwwwwwwwwww", "#")]
        [TestCase(1, "", 2002, "USA", "ewww", "Roman", "wwwwwwwwwwwwww", "#")]
        [TestCase(2, "Movie3", 2002, "USA", "ewww", "Roman", "wwwwwwwwwwwwww", "#")]
        public void ClearContentsTest(int id, string name, int year, string country, string producer, string genry, string anotation, string img)
        {
            var movie = new Movie()
            {
                Id = id,
                Name = name,
                Year = year,
                Country = country,
                Producer = producer,
                Genre = genry,
                Annotation = anotation,
                Img = img,
            };

            CartTwo cart = new CartTwo();

            cart.AddItem(movie, 1);
            cart.AddItem(movie, 1);
            cart.AddItem(movie, 5);
            cart.Clear();

            Assert.AreEqual(cart.Lines.Count(), 0);

        }


    }
}
