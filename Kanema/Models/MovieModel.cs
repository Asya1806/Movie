using Kanema.Models.Movies;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kanema.Models
{
    /// <summary>
    /// Модель представляющая фильм
    /// </summary>
    public class MovieModel
    {
        /// <summary>
        /// Уникальное id фильма.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название фильма.
        /// </summary>
        [Required(ErrorMessage = "Не указано название фильм.")]
        public string Name { get; set; }

        /// <summary>
        /// Год фильма.
        /// </summary>
        [Required(ErrorMessage = "Не указан год фильма.")]
        public int Year { get; set; }

        /// <summary>
        /// Страна фильма.
        /// </summary>
        [Required(ErrorMessage = "Ну указана страна фильма.")]
        public string Country { get; set; }

        /// <summary>
        /// Режиссер фильма.
        /// </summary>
        [Required(ErrorMessage = "Ну указана режиссер фильма.")]
        public string Producer { get; set; }

        /// <summary>
        /// Жанр фильма.
        /// </summary>
        [Required(ErrorMessage = "Ну указана жанр фильма.")]
        public string Genre { get; set; }

        /// <summary>
        /// Аннотация фильма.
        /// </summary>
        [Required(ErrorMessage = "Ну указана аннотация фильма.")]
        public string Annotation { get; set; }

        public int Category { get; set; }

        /// <summary>
        /// Картинка фильма.
        /// </summary>
        public IFormFile Img { get; set; }
    }
}
