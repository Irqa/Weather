using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models.ViewModels
{
    public class RegisterModel
    {
        [Required(ErrorMessage ="Не вказаний Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage ="Не вказаний пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Пароль не співпадає")]
        public string ConfirmPassword { get; set; }
    }
}
