using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Kanema.Models.Movies
{
    public class Movie : IEquatable<Movie>
    {
        /// <summary>
        /// Id фильма
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Изображение фильма фильма
        /// </summary>
        public string Img { get; set; }

        /// <summary>
        /// Название фильма
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Год издания
        /// </summary>
        [Range(1, 110, ErrorMessage = "Недопустимый год")]
        public int Year { get; set; }

        /// <summary>
        /// Страна создания фильма
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Режиссер фильма
        /// </summary>
        public string Producer { get; set; }

        /// <summary>
        /// Жанр фильма
        /// </summary>
        public string Genre { get; set; }

        /// <summary>
        /// Краткое оптисание фильма
        /// </summary>
        public string Annotation { get; set; }

        public int? CategoryId { get; set; }

        public Category Category { get; set; }

        public bool Equals(Movie other)
        {
            if (other is null)
            {
                return false;
            }

            if (GetHashCode() != other.GetHashCode())
            {
                return false;
            }

            return other.Id == Id && string.Equals(other.Name, this.Name) && string.Equals(other.Year, this.Year) && string.Equals(other.Country, this.Country) && string.Equals(other.Producer, this.Producer) && string.Equals(other.Genre, this.Genre) && other.Annotation == Annotation && string.Equals(other.Img, this.Img);
        }

        public override bool Equals(object obj)
        {
            try
            {
                return this.Equals((Movie)obj);
            }
            catch
            {
                return false;
            }
            //var other = obj as Movie;

            //if (other is null)
            //{
            //    return false;
            //}

            //return this.Equals(other);
        }

        public override int GetHashCode()
        {
            int res = this.Id;
            res <<= 11;
            res ^= Year;
            res <<= 1;
            //res ^= CategoryId.Value;

            return res;
        }
    }
}