using Kanema.Controllers;
using Kanema.Models;
using Kanema.Models.Movies;
using Kanema.Models.Users;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanema.Test.Controllers
{
    //[TestClass]
    [TestFixture]
    public class IntegrityTest
    {
        //[TestCase("nastyaZhdanova02", "qwertyuiop", "qwertyuiop", true)]
        //public void test_checkOnValidLoginAndPasswor_ExceptTrue(string login, string password, string confirmpassword,  bool expected)
        //{
        //    AccountValidator accountValidator = new AccountValidator();
        //    var actual = accountValidator.VerifyLogin(login);
        //    Assert.AreEqual(actual, expected);

        //    actual = accountValidator.VerifyPassword(password);
        //    Assert.AreEqual(actual, expected);

        //    actual = accountValidator.CheckIsEmpty(login);
        //    Assert.AreEqual(actual, expected);

        //    actual = accountValidator.CheckIsEmpty(password);
        //    Assert.AreEqual(actual, expected);

        //    actual = accountValidator.VerifyConfirmPassword(password, confirmpassword);
        //    Assert.AreEqual(actual, expected);

        //    actual = accountValidator.VerifyData(login, password, confirmpassword);
        //    Assert.AreEqual(actual, expected);

        //    actual =AccountController.Register()
        //}

        //public void test_register(string login, string password)
        //{
        //    AccountValidator accountValidator = new AccountValidator();
        //    var mock = new Mock<IUserService>();
        //    mock.Setup(m => m.GetUser(login, password)).Returns(GetTestUsers());
        //    AccountController accountController = new AccountController(mock, accountValidator);
        //}

        private List<User> GetTestUsers()
        {
            var users = new List<User>
            {
                new User { Id=1, Login="Tom", Password="qwertyuiop"},
                new User { Id=2, Login="Alice", Password="poiuytrewq"},
                new User { Id=3, Login="Sam", Password="asdfghjkl"},
                new User { Id=4, Login="Kate", Password="zxcvbnmrr"}
            };
            return users;
        }




        [TestCase("Чарли и шоколадная фабрика", 2005, "США, Великобритания", "Тим Бёртон", "Музыкальный", "Какие чудеса ждут вас на фабрике Вилли Вонки?", "CharlieChocolateFactory.jpg", 1)]
        public void test_checkOnValidDataForAddMovie_ExceptTrue(string name, int year, string country, string producer, string genre, string annotation, string img, int categoryId)
        {
            AccountValidator accountValidator = new AccountValidator();

            bool expected = true;
            var actual = accountValidator.CheckIsEmpty(name);
            Assert.AreEqual(actual, expected);

            expected = false;
            actual = accountValidator.CheckForDigits(year.ToString());
            Assert.AreEqual(actual, expected);
            expected = true;

            actual = accountValidator.CheckIsEmpty(country);
            Assert.AreEqual(actual, expected);

            expected = true;
            actual = accountValidator.CheckIsEmpty(producer);
            Assert.AreEqual(actual, expected);

            expected = true;
            actual = accountValidator.CheckIsEmpty(genre);
            Assert.AreEqual(actual, expected);

            expected = true;
            actual = accountValidator.CheckIsEmpty(annotation);
            Assert.AreEqual(actual, expected);

            expected = true;
            actual = accountValidator.CheckIsEmpty(img);
            Assert.AreEqual(actual, expected);

            expected = false;
            actual = accountValidator.CheckForDigits(categoryId.ToString());
            Assert.AreEqual(actual, expected);
            //  DbContextOptions<MovieContext> options= new DbContextOptions<MovieContext>();

            //Database database = new Database("Server=(localdb)\\mssqllocaldb;Database=KanemaUserDB;Trusted_Connection=True;");
            //MovieContext movieContex = new MovieContext(UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=KanemaUserDB;Trusted_Connection=True;");
            //MovieContext movieContext = new MovieContext(options => options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Movies;Trusted_Connection=True;");
            //MovieService movieService = new MovieService();
            //var mock = new Mock<MovieContext>();
            //mock.Setup(o => o.Add(mock));
            //MovieService movieService = new MovieService(mock.Object);

            //actual = movieService.CreateMovie(name,year,country,producer,genre,annotation,img,categoryId);
            //Assert.AreEqual(actual, expected);
        }

        //[TestCase("Чарли и шоколадная фабрика", true)]//, "2005", "США, Великобритания", "Тим Бёртон", "Музыкальный", "Какие чудеса ждут вас на фабрике Вилли Вонки?", "~/img/CharlieChocolateFactory.jpg", 1, true)]
        //public void test_checkOnValidDataForAddMovie_ExceptTrue(string name, bool expected)//, string year, string country, string producer, string genre, string annotation, string category, string img, bool expected)
        //{
        //    AccountValidator accountValidator = new AccountValidator();
        //    //MovieModel movieModel = new MovieModel();

        //    var actual = accountValidator.CheckIsEmpty(name);
        //    Assert.AreEqual(actual, expected);

        //    MoviesController moviesController = new MoviesController();

        //    var result = moviesController.Search(name);// id, name, year, country, producer, genre,annotation, category, img);
        //                                               // var viewResult = Assert.IsInstanceOf<Task<IActionResult>>(result);
        //                                               //var modelResult = Assert.IsInstanceOf<ViewResult>(Assert.IsInstanceOf<Task<IActionResult>>(result).Result);


        //    actual = accountValidator.VerifyData(login, password, confirmpassword);
        //    Assert.AreEqual(actual, Assert.IsInstanceOf<ViewResult>(Assert.IsInstanceOf<Task<IActionResult>>(result).Result) ? Model);
        //}

        //[TestCase("asdfg12345", true)]
        //[InlineData("", "", true)]
        //[InlineData("123", "H1", "Duhlia for pretty girls", "Duhlias", "10", false)]
        //public void checkInsertDataTest(string login, string password, bool expected)
        //{
        //    AccountValidator accountValidator = new AccountValidator();

        //    bool actual = accountValidator.CheckIsEmpty(login);
        //    Assert.AreEqual(actual, expected);

        //    actual = accountValidator.CheckIsEmpty(password);
        //    Assert.AreEqual(actual, expected);

        //    actual = accountValidator.VerifyLogin(login);
        //    Assert.AreEqual(actual, expected);

        //    //actual = AccountValidator.CheckForDigits(flowerId.ToString());
        //    //Assert.AreEqual(actual, expected);

        //    //actual = AccountValidator.CheckForDigits(price.ToString());
        //    //Assert.AreEqual(actual, expected);
        //    IUserService _userService;
        //    //MoviesController moviesController = new MoviesController(MovieModel movie);
        //    AccountController accountController = new AccountController(_userService, accountValidator);
        //    actual = accountController.Login();
        //    Assert.AreEqual(actual, expected);

        //MovieContext _movieContext;
        //MovieService _movieService;
        //Movie testMovie1;
        //Movie testMovie2;
        //Movie testMovie3;
        //[TestInitialize()]
        //public void Startup()
        //{
        //    MovieService _movieService = new MovieService(_movieContext);
        //    Movie testMovie1 = new Movie
        //    {
        //        Id = 1,
        //        Name = "Чарли и шоколадная фабрика",
        //        Year = 2005,
        //        Country = "США, Великобритания",
        //        Producer = "Тим Бёртон",
        //        Img = "../img/CharlieChocolateFactory.jpg",
        //        Genre = "Музыкальный",
        //        Annotation = "Какие чудеса ждут вас на фабрике Вилли Вонки? Только представьте: травяные луга из сладкого мятного сахара в Шоколадной Комнате ... Можно проплыть по Шоколадной реке на розовой сахарной лодке ... Или поставить эксперименты в Комнате изобретений с леденцами, которые никогда не тают ... Понаблюдать за дрессированными белками в Ореховой Комнате или отправиться в стеклянном лифте в Телевизионную Комнату. Вы найдете слишком много смешного, чуть таинственного и настолько захватывающего в этом путешествии, что оно станет настолько же приятным и сладким для вас, как восхитительная сладкая палочка с розовой сливочной помадкой от Вилли Вонки.",
        //        CategoryId=1
        //        //Category = _moviesCategory.AllCategories.First()
        //    };
        //    Movie testMovie2 = new Movie
        //    {
        //        Id = 2,
        //        Name = "Дом странных детей Мисс Перегрин",
        //        Year = 2016,
        //        Country = "США, Великобритания",
        //        Producer = "Тим Бёртон",
        //        Img = "../img/Miss_Peregrine's_Home_for_Peculiar_Children_.jpg",
        //        Genre = "Фэнтези, Приключения",
        //        Annotation = "Детство Джейкоба прошло под рассказы дедушки о приюте для необычных детей. Среди его обитателей девочка, которая умела держать в руках огонь, девочка, чьи ноги не касались земли, невидимый мальчик и близнецы, умевшие общаться без слов. Когда дедушка умирает, 16-летний Джейкоб получает загадочное письмо и отправляется на остров, где вырос его дед. Там он находит детей, которых раньше видел только на фотографиях.",
        //        CategoryId=1
        //        //Category = "Фильм" //_moviesCategory.AllCategories.First()
        //    };
        //    Movie testMovie3 = new Movie
        //    {
        //        Id = 3,
        //        Name = "Холодное сердце",
        //        Year = 2013,
        //        Country = " США, Норвегия",
        //        Producer = "Дженнифер Ли, Крис Бак",
        //        Img = "../img/Frozen.jpg",
        //        Genre = "Семейный, Фэнтези, Мюзикл, Приключения, Комедия",
        //        Annotation = "Когда сбывается древнее предсказание, и королевство погружается в объятия вечной зимы, трое бесстрашных героев - принцесса Анна, отважный Кристофф и его верный олень Свен - отправляются в горы, чтобы найти сестру Анны, Эльзу, которая может снять со страны леденящее заклятие. По пути их ждет множество увлекательных сюрпризов и захватывающих приключений: встреча с мистическими троллями, знакомство с очаровательным снеговиком по имени Олаф, горные вершины покруче Эвереста и магия в каждой снежинке. Анне и Кристоффу предстоит сплотиться и противостоять могучей стихии, чтобы спасти королевство и тех, кто им дорог.",
        //        CategoryId=3
        //        //Category = "Мультфильм" //_moviesCategory.AllCategories.ElementAt(3)
        //    };
        //}

        //[TestMethod]
        //public void change_can_Change_Movie_return_true()
        //{
        //    _movieService.AddMovie(testMovie1);
        //    IWebHostEnvironment appEnvironment;
        //    IMovieService movieService;
        //    MoviesController moviesController = new MoviesController(appEnvironment, movieService);
        //    Movie movie1 = moviesController.Create(1).ViewData.Model as Movie;
        //    Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(1, movie1.Id);
        //}



    }
}
