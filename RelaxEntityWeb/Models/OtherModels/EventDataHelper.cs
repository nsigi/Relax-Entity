namespace RelaxEntityWeb.Models.OtherModels
{
	public class EventDataHelper
	{
		public EventDataHelper()
		{
			CurrentEventId = -1;
		}

		public int Id { get; set; }

		public string Name { get; set; } = null!;

		public DateTime Date { get; set; }

		public TimeSpan StartTime { get; set; }

		public int CountMax { get; set; }

		public int CountCurrent { get; set; }

		public string? Note { get; set; }

		public decimal Price { get; set; }

		public int PmId { get; set; }

		public int Status { get; set; }

		public string Location { get; set; }

		public string Programm { get; set; }

		public int CurrentEventId { get; set; }
	}
}
