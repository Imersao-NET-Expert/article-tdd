namespace Parking.Domain
{
    public class Calculation
    {
        public double Price { get; }
        public string? Message { get;  }

        public Calculation(string message)
        {
            Message = message;
        }

        public Calculation(double price)
        {
            Price = price;
        }
    }
}