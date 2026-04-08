using VehicleRental.App;
using Xunit;

namespace VehicleRental.Tests;

public class VehicleExtensionsTests
{
    [Fact]
    public void GetAvailableVehicles_ShouldReturnOnlyAvailable()
    {
        var vehicles = new List<Vehicle>
        {
            new Car(1, "Toyota", "Corolla", 2020, "Sedan"),
            new Car(2, "BMW", "X5", 2022, "SUV"),
            new Motorcycle(3, "Yamaha", "MT-07", 2021, 689)
        };

        // rezerwujemy jeden pojazd
        ((IReservable)vehicles[1]).Reserve("Klient");

        var available = vehicles.GetAvailableVehicles();

        Assert.Equal(2, available.Count);
        Assert.DoesNotContain(vehicles[1], available);
    }

    [Fact]
    public void GetAvailableVehicles_WhenAllReserved_ShouldReturnEmpty()
    {
        var vehicles = new List<Vehicle>
        {
            new Car(1, "Toyota", "Corolla", 2020, "Sedan")
        };
        ((IReservable)vehicles[0]).Reserve("Klient");

        var available = vehicles.GetAvailableVehicles();

        Assert.Empty(available);
    }
}