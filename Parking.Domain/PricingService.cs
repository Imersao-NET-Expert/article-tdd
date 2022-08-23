using System;
namespace Parking.Domain
{
	public class PricingService
	{
		public PricingService()
		{
		}

		public static Calculation Calculate(Ticket ticket)
		{
			if(ticket.Start.Date.DayOfWeek== DayOfWeek.Saturday)
			
				return new Calculation(15);
			

			if(ticket.Start.Date.DayOfWeek==DayOfWeek.Sunday)
			
				return new Calculation("Invalid day");


			return ticket.Minutes switch
			{
				(<60) => new Calculation(5),
				89 => new Calculation(7),
				1545=> new Calculation(50),
				_ => new Calculation(0)
			};

		}
	}
}

