namespace RelaxEntityWeb.Models.OtherModels
{
	public static class DayOfWeekExtensions
	{
		public static string[] DayOfWeekOnRus = new[]
		{
			"понедельник",
			"вторник",
			"среда",
			"четверг",
			"пятница",
			"суббота",
			"воскресенье"
		};

		public static string ToRus(this DayOfWeek day)
		{
			int numberOfDay = (int)day;
			return DayOfWeekOnRus[(numberOfDay + 7 - 1) % 7];
		}
	}
}
