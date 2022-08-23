using System;
using Parking.Domain;

namespace ParkingTests
{
	public class PricingRepositoryTest : IPricingRepository
	{

        public Period[] GetPeriodsFromDayOfWeek(DayOfWeek dayOfWeek)
        {
			if (dayOfWeek == DayOfWeek.Sunday)
				return new Period[0];

			if (dayOfWeek == DayOfWeek.Saturday)
				return new Period[]
				{
					new Period(15,1440, PeriodTypeEnum.Fixed)
				};

			return new Period[]
			{
				new Period(5, 60, PeriodTypeEnum.Fixed),
				new Period(2, 60, PeriodTypeEnum.Additional),
				new Period(25, 24 * 60, PeriodTypeEnum.FullDay)
			};

        }
    }
}

