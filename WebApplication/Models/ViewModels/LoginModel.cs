﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models.ViewModels
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Не вказаний Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage ="Не вказаний пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}