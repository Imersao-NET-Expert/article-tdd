namespace Parking.Domain;
public class Ticket
{

    public Ticket(DateTime start, DateTime end)
    {
        Start = start;
        End = end;
    }

    public DateTime Start { get; }
    public DateTime End { get; }

    public int Minutes {
        get
        {
            return (int)End.Subtract(Start).TotalMinutes;
        }

    }
    

    
}

