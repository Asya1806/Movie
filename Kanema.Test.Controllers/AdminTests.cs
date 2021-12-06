//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Kanema.Controllers;
//using Kanema.Models.Movies;
//using Moq;
//using NUnit.Framework;

//namespace Kanema.Test.Controllers
//{
//    [TestFixture]
//    class AdminTests
//    {
//        [Test]
//        public void Index_Contains_All_Movie()
//        {
//            // arrange (организация - создание имитированного хранилища данных)
//            Mock<IRepository> mock = new Mock<IRepository>();
//            mock.Setup(m => m.Movies).Returns(new List<Movie>
//            {
//                new Movie {
//                    Id=1,
//                    Name="Фильм1",
//                    Year=2005,
//                    Country="США",
//                    Producer="Тим Бёртон",
//                    Img="/img/CharlieChocolateFactory.jpg",
//                    Genre="Музыкальный",
//                    Annotation="Какие чудеса ждут вас на фабрике Вилли Вонки? Только представьте: травяные луга из сладкого мятного сахара в Шоколадной Комнате ... Можно проплыть по Шоколадной реке на розовой сахарной лодке ... Или поставить эксперименты в Комнате изобретений с леденцами, которые никогда не тают ... Понаблюдать за дрессированными белками в Ореховой Комнате или отправиться в стеклянном лифте в Телевизионную Комнату. Вы найдете слишком много смешного, чуть таинственного и настолько захватывающего в этом путешествии, что оно станет настолько же приятным и сладким для вас, как восхитительная сладкая палочка с розовой сливочной помадкой от Вилли Вонки."
//                    //Category=_moviesCategory.AllCategories.First()
//                },
//                new Movie {
//                    Id=2,
//                    Name="Фильм2",
//                    Year=2016,
//                    Country="США",
//                    Producer="Тим Бёртон",
//                    Img="",
//                    Genre="Фэнтези, Приключения",
//                    Annotation=""
//                    //Category=_moviesCategory.AllCategories.First()
//                },
//                new Movie {
//                    Id=3,
//                    Name="Фильм3",
//                    Year=2002,
//                    Country="ккк",
//                    Producer="ццц",
//                    Img="",
//                    Genre="",
//                    Annotation=""
//                    //Category=_moviesCategory.AllCategories.ElementAt(3) }
//                    }
//            });

//            // Организация - создание контроллера
//            AdminController controller = new AdminController(mock.Object);

//            // Действие
//            List<Movie> result = ((IEnumerable<Movie>)controller.Index().
//                ViewData.Model).ToList();

//            // Утверждение
//            Assert.AreEqual(result.Count(), 3);
//            Assert.AreEqual("Фильм1", result[0].Name);
//            Assert.AreEqual("Фильм2", result[1].Name);
//            Assert.AreEqual("Фильм3", result[2].Name);
//        }
//    }
//}