using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SimpleNotes.Models
{
    public class AddModel
    {
        [Required(ErrorMessage = "Введите название")]
        [Display(Name = "Название*")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите текст заметки")]
        [Display(Name = "Текст заметки*")]
        public string Text { get; set; }

        [Display(Name = "Введите теги")]
        public string[] Tag { get; set; }

        [Display(Name = "Опубликовать?")]
        public bool Published { get; set; }

        public HttpPostedFileBase File { get; set; }
    }
}