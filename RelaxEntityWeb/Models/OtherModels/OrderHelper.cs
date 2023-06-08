using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace RelaxEntityWeb.Models.OtherModels
{
	public class OrderHelper
	{
		public OrderHelper()
		{
			CurrentEventId = -1;
			QuantityOfPeople = -1;
			CurrentOrderId = -1;
		}
        public int CurrentEventId { get; set; }

		public int QuantityOfPeople { get; set; }

        public int CurrentOrderId { get; set; }

    }
}
