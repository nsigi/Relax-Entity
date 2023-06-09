namespace RelaxEntityWeb.Models.OtherModels
{
	public class ProgramDataHelper
	{
        public ProgramDataHelper()
        {
			CurrentProgramId = -1;
        }

		public string Name { get; set; }

		public string Description { get; set; }

		public TimeSpan Duration { get; set; }

		public int Age { get; set; }

		public override string ToString()
		{
			return string.Format("{0} {1} {2} {3}", Name, Description, Duration, Age);
		}

		public int CurrentProgramId { get; set; }

	}
}
