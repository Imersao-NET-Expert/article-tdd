namespace Parking.Domain
{
    public interface IPricingRepository
    {
        Period[] GetPeriodsFromDayOfWeek(DayOfWeek dayOfWeek);
    }
}