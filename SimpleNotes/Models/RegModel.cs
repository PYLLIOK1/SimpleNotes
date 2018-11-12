using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SimpleNotes.Models
{
    public class RegModel
    {
        [Required(ErrorMessage = "Введите логин")]
        [Display(Name = "Логин*")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [Display(Name = "Пароль*")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [Display(Name = "Повторите пароль*")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
    }
}