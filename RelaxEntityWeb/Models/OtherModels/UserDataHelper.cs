using RelaxEntityWeb.Controllers;
using System.ComponentModel.DataAnnotations;

namespace RelaxEntityWeb.Models.OtherModels
{
	public class UserDataHelper
	{
        public UserDataHelper()
        {

		}

		[Required(ErrorMessage = "Введите имя")]
		[MaxLength(100, ErrorMessage = "Максимум 100 символов")]
		[MinLength(3, ErrorMessage = "Минимум 3 символа")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Введите номер телефона")]
		[MaxLength(50, ErrorMessage = "Максимум 50 символов")]
		[MinLength(11, ErrorMessage = "Минимум 3 символа")]
		public string Phone { get; set; }

		[MaxLength(30, ErrorMessage = "Максимум 30 символов")]
		[MinLength(11, ErrorMessage = "Минимум 3 символа")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Введите почту")]
		[MaxLength(100, ErrorMessage = "Максимум 100 символов")]
		[MinLength(3, ErrorMessage = "Минимум 3 символа")]
		public string Organization { get; set; }

		[DataType(DataType.Password)]
		[Required(ErrorMessage = "Введите пароль")]
		[MaxLength(32, ErrorMessage = "Максимум 32 символа")]
		[MinLength(6, ErrorMessage = "Минимум 6 символов")]
		public string Password { get; set; }

		[DataType(DataType.Password)]
		[Required(ErrorMessage = "Подтвердите пароль")]
		[Compare("Password", ErrorMessage = "Пароли не совпадают")]
		public string PasswordConfirm { get; set; }

		public override string ToString()
		{
			return string.Format("{0} {1} {2} {3} {4}", Name, Phone, Email, Organization, Password);
		}
	}
}
