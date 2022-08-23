namespace Parking.Domain;
public class Ticket
{
    private readonly int minutes;
    private readonly int fullDays;
    private const int minutesInDay = 24 * 60;

    public Ticket(DateTime start, DateTime end)
    {
        Start = start;
        End = end;
        minutes = (int)End.Subtract(Start).TotalMinutes;
        fullDays = CalculateFullDays(minutes);
    }

    public DateTime Start { get; }
    public DateTime End { get; }

    public int Minutes => minutes;
    public int FullDays => fullDays;
    public bool HasFullDays => fullDays > 0;


    private int CalculateFullDays(int minutes)
    {

        if (minutes < minutesInDay)
            return 0;

        var mod = minutes % minutesInDay;
        return
            ((minutes - mod) / minutesInDay)
            + (mod > 0 ? 1 : 0);
    }



}

