namespace RelaxEntityWeb.Models.OtherModels
{
	public class LocationDataHelper
	{
		public LocationDataHelper()
		{
			CurrentLocationId = -1;
		}
		public string Name { get; set; }

		public int Capaciousness { get; set; }

		public string Equipment { get; set; }

		public override string ToString()
		{
			return string.Format("{0} {1} {2}", Name, Capaciousness, Equipment);
		}

		public int CurrentLocationId { get; set; }
	}
}
