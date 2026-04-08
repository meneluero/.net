using VehicleRental.App;
using Xunit;

namespace VehicleRental.Tests;

public class ReservationTests
{
    [Fact]
    public void Reservation_ShouldStoreCorrectData()
    {
        var car = new Car(1, "Toyota", "Corolla", 2020, "Sedan");
        var reservation = new Reservation(1, car, "Jan Kowalski");

        Assert.Equal(1, reservation.ReservationId);
        Assert.Equal(car, reservation.ReservedVehicle);
        Assert.Equal("Jan Kowalski", reservation.Customer);
        Assert.True(reservation.ReservationDate <= DateTime.Now);
    }

    [Fact]
    public void Reservation_ToString_ShouldContainKeyInfo()
    {
        var car = new Car(1, "Toyota", "Corolla", 2020, "Sedan");
        var reservation = new Reservation(1, car, "Jan Kowalski");
        var str = reservation.ToString();

        Assert.Contains("Jan Kowalski", str);
        Assert.Contains("Toyota", str);
        Assert.Contains("Corolla", str);
        Assert.Contains("#1", str);
    }
}