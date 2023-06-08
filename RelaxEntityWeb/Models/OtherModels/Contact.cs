using System.ComponentModel.DataAnnotations;

namespace RelaxEntityWeb.Models.OtherModels
{
    public class Contact
    {
        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Вам нужно ввести имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Вам нужно ввести фамилию")]
        [Display(Name = "Фамилия")]
        public string SurName { get; set; }

        [Required(ErrorMessage = "Вам нужно ввести возраст")]
        [Display(Name = "Возраст")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Вам нужно ввести сообщение")]
        [Display(Name = "Сообщение")]
        public string Message { get; set; }

        [Required(ErrorMessage = "Вам нужно ввести почту")]
        [Display(Name = "Электронная почта")]
        [StringLength(30, ErrorMessage = "Сообщение не менее 30 символов")]
        public string Email { get; set; }
    }
}
