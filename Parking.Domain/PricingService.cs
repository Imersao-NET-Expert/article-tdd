using System;
namespace Parking.Domain
{
    public class PricingService
    {
        private readonly IPricingRepository repository;
        private readonly int tolerance;

        public PricingService(IPricingRepository repository, int tolerance)
        {
            this.repository = repository;
            this.tolerance = tolerance;
        }



        public Calculation Calculate(Ticket ticket)
        {

            if (ticket.Minutes <= tolerance)
                return new Calculation(0);

            var periods = repository.GetPeriodsFromDayOfWeek(ticket.Start.DayOfWeek);

            if (periods.Length == 0)
                return new Calculation("Invalid day");

            bool hasFullDay = HasFullDay(periods);

            return (hasFullDay && ticket.HasFullDays)
                ? CalculatePriceWithFullDay(ticket, periods)
                : CalculatePrice(ticket, periods);
        }




        private static Calculation CalculatePrice(Ticket ticket, Period[] periods)
        {

            double price = 0.0;
            int duration = 0;

            foreach (var period in periods)
            {

                switch (period.periodType)
                {
                    case PeriodTypeEnum.Fixed:
                        price = period.Price;
                        duration = period.Minutes;
                        break;

                    case PeriodTypeEnum.Additional:

                        while (duration <= ticket.Minutes)
                        {

                            price += period.Price;
                            duration += period.Minutes;
                        }
                        break;
                }


                if (duration >= ticket.Minutes)
                    break;
            }



            return new Calculation(price);
        }

        private Calculation CalculatePriceWithFullDay(Ticket ticket, Period[] periods)
        {
            var fullDayPeriod = periods.First(f => f.periodType == PeriodTypeEnum.FullDay);
            return new Calculation(fullDayPeriod.Price * ticket.FullDays);
        }

        private bool HasFullDay(Period[] periods)
        {
            return periods.Any(p => p.periodType == PeriodTypeEnum.FullDay);
        }
    }
}

