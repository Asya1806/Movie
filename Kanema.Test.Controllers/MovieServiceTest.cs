using Kanema.Models.Movies;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanema.Test.Controllers
{
    [TestFixture]
    class MovieServiceTest
    {
        private static DbContextOptionsBuilder<MovieContext> _dbContextOptionsBuilder = new DbContextOptionsBuilder<MovieContext>();
        private static MovieService _movieService = new MovieService(new MovieContext(_dbContextOptionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Test;Trusted_Connection=True;").Options));

        [TestCase("Movie", ExpectedResult = true)]
        [TestCase("Movie", ExpectedResult = false)]
        public bool CreateMovieTest(string name) => _movieService.CreateMovie(name, 0, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, 0);
            
        [TestCase("Movie", ExpectedResult = true)]
        [TestCase("Movie", ExpectedResult = false)]
        public bool RemoveMovieTest(string name) => _movieService.RemoveMovie(new Movie()
        {
            Id = 1,
            Name = name,
            Year = 0,
            Country = string.Empty,
            Producer = string.Empty,
            Genre = string.Empty,
            Annotation = string.Empty,
            Img = string.Empty,
        });
    }
}
