using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kanema.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Поле логин не заполнено")]
        //[EmailAddress(ErrorMessage = "Некорректный адрес")]
        [StringLength(40, ErrorMessage = "Логин должен быть от 8 до 40 символов", MinimumLength = 8)]
        [Display(Name = "Login")]
        public string Login { get; set; }
       
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Поле пароль не заполнено")]
        [StringLength(20, ErrorMessage = "Пароль должен быть от 8 до 20 символов", MinimumLength = 8)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Пароли не совпадают")]
        [StringLength(20, ErrorMessage = "Пароль должен быть от 8 до 20 символов", MinimumLength = 8)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
        public int Year { get; set; }
    }
}
