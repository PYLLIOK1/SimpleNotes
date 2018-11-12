using System.ComponentModel.DataAnnotations;

namespace SimpleNotes.Models
{
    public class EditModel
    {
        [Required(ErrorMessage = "Введите текст заметки")]
        [Display(Name = "Текст заметки*")]
        public string Text { get; set; }

        [Display(Name = "Опубликовать?")]
        public bool Published { get; set; }
    }
}