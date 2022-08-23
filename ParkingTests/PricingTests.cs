using System;
using System.Net.Sockets;
using Parking.Domain;

namespace ParkingTests;

public class PricingTests
{


    public static readonly object[][] ValidTestData =
    {
        new object[] {  new DateTime(2022,8,22,9,0,0), new DateTime(2022, 8, 22, 10, 29, 0), 7 },
        new object[] {  new DateTime(2022,8,22,12,10,0), new DateTime(2022, 8, 22, 12, 25, 0), 5 },
        new object[] {  new DateTime(2022,8,23,10,25,0), new DateTime(2022, 8, 24, 12, 10, 0), 50 },
        new object[] {  new DateTime(2022,8,27,9,0,0), new DateTime(2022, 8, 27, 12, 4, 0), 15 }
    };

    public static readonly object[][] InvalidTestData =
    {
        new object[] {  new DateTime(2022,8,28,10,15,0), new DateTime(2022, 8, 28, 12, 15, 0) },
    };



    [Theory, MemberData(nameof(ValidTestData))]
    public void Calculate_Success(DateTime startDateTime, DateTime endDateTime, double expectedResult)
    {
        //arrange
        var ticket = new Ticket(startDateTime, endDateTime);

        //act
        var calculation = PricingService.Calculate(ticket);

        //assert
        Assert.Equal(expectedResult, calculation.Price);
    }



    [Theory, MemberData(nameof(InvalidTestData))]
    public void Invalid_Day_Throws_Error(DateTime startDateTime, DateTime endDateTime)
    {

        //arrange
        var ticket = new Ticket(startDateTime, endDateTime);

        //act
        var calculation = PricingService.Calculate(ticket);

        //assert
        Assert.NotEmpty(calculation.Message);

    }
}
