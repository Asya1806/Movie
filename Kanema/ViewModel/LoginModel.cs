using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kanema.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Не указан Login(Email)")]
       // [EmailAddress(ErrorMessage = "Некорректный адрес")]
       // [StringLength(40, ErrorMessage = "Логин должен быть от 8 до 40 символов", MinimumLength = 8)]
        public string Login { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
     //   [StringLength(20, ErrorMessage = "Пароль должен быть от 8 до 20 символов", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
