using Kanema.Models.Bookmarks;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kanema.Models.Users
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        //[RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        //[Required(ErrorMessage = "Не указан логин")]
        //[Remote(action: "CheckLogin", controller: "Home", ErrorMessage = "Login уже используется")]
        //[StringLength(40, MinimumLength = 2, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string Login { get; set; }
        
        //[Required]
        public string Password { get; set; }
        public int? RoleId { get; set; }
        public Role Role { get; set; }

        //public int? BookmarkId { get; set; }

        //public Bookmark Bookmark { get; set; }

        //год рождения пользователя
      //  public int Year { get; set; }
    }
}
