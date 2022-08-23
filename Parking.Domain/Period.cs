namespace Parking.Domain
{
    public class Period
    {
        public Period(double price, int minutes, PeriodTypeEnum periodType)
        {
            Price = price;
            Minutes = minutes;
            this.periodType = periodType;
        }

        public  double Price { get; }
        public  int Minutes { get; }
        public PeriodTypeEnum periodType { get; }
    }

    public enum PeriodTypeEnum
    {
        Fixed=1,
        Additional=2,
        FullDay=3
    }
}