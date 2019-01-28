using System.ComponentModel.DataAnnotations;

namespace RolesApp.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Не указано Имя")]
        public string Name { get; set; }

        [Required(ErrorMessage ="не указана Фамилия")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Не выбран цвет")]
        public string Color { get; set; }

        [Required(ErrorMessage = "не выбран напиток")]
        public string Pot { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароль введен неверно")]
        public string ConfirmPassword { get; set; }
    }
}
