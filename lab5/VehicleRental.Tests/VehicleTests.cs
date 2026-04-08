using VehicleRental.App;
using Xunit;

namespace VehicleRental.Tests;

public class VehicleTests
{
    [Fact]
    public void Car_ShouldHaveCorrectAttributes()
    {
        var car = new Car(1, "Toyota", "Corolla", 2020, "Sedan");

        Assert.Equal(1, car.Id);
        Assert.Equal("Toyota", car.Brand);
        Assert.Equal("Corolla", car.Model);
        Assert.Equal(2020, car.Year);
        Assert.Equal("Sedan", car.BodyType);
        Assert.True(car.IsAvailable);
    }

    [Fact]
    public void Motorcycle_ShouldHaveCorrectAttributes()
    {
        var moto = new Motorcycle(2, "Yamaha", "MT-07", 2021, 689);

        Assert.Equal(2, moto.Id);
        Assert.Equal("Yamaha", moto.Brand);
        Assert.Equal("MT-07", moto.Model);
        Assert.Equal(2021, moto.Year);
        Assert.Equal(689, moto.EngineCapacity);
        Assert.True(moto.IsAvailable);
    }

    [Fact]
    public void Car_Reserve_ShouldSetIsAvailableToFalse()
    {
        var car = new Car(1, "Toyota", "Corolla", 2020, "Sedan");
        car.Reserve("Jan Kowalski");

        Assert.False(car.IsAvailable);
    }

    [Fact]
    public void Car_CancelReservation_ShouldSetIsAvailableToTrue()
    {
        var car = new Car(1, "Toyota", "Corolla", 2020, "Sedan");
        car.Reserve("Jan Kowalski");
        car.CancelReservation();

        Assert.True(car.IsAvailable);
    }

    [Fact]
    public void Car_Reserve_WhenNotAvailable_ShouldThrow()
    {
        var car = new Car(1, "Toyota", "Corolla", 2020, "Sedan");
        car.Reserve("Jan Kowalski");

        Assert.Throws<InvalidOperationException>(() => car.Reserve("Anna Nowak"));
    }

    [Fact]
    public void Motorcycle_Reserve_ShouldSetIsAvailableToFalse()
    {
        var moto = new Motorcycle(2, "Yamaha", "MT-07", 2021, 689);
        moto.Reserve("Anna Nowak");

        Assert.False(moto.IsAvailable);
    }
}