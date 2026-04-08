using VehicleRental.App;
using Xunit;

namespace VehicleRental.Tests;

public class RentalCompanyTests
{
    [Fact]
    public void AddVehicle_ShouldIncreaseVehicleCount()
    {
        var company = new RentalCompany();
        company.AddVehicle(new Car(1, "Toyota", "Corolla", 2020, "Sedan"));

        Assert.Single(company.GetAllVehicles());
    }

    [Fact]
    public void ReserveVehicle_ShouldCreateReservation()
    {
        var company = new RentalCompany();
        company.AddVehicle(new Car(1, "Toyota", "Corolla", 2020, "Sedan"));
        company.ReserveVehicle(1, "Jan Kowalski");

        Assert.Single(company.GetAllReservations());
        Assert.False(company.GetAllVehicles()[0].IsAvailable);
    }

    [Fact]
    public void CancelReservation_ShouldMakeVehicleAvailableAgain()
    {
        var company = new RentalCompany();
        company.AddVehicle(new Car(1, "Toyota", "Corolla", 2020, "Sedan"));
        company.ReserveVehicle(1, "Jan Kowalski");
        company.CancelReservation(1);

        Assert.Empty(company.GetAllReservations());
        Assert.True(company.GetAllVehicles()[0].IsAvailable);
    }

    [Fact]
    public void ReserveVehicle_WithInvalidId_ShouldThrow()
    {
        var company = new RentalCompany();

        Assert.Throws<ArgumentException>(() => company.ReserveVehicle(99, "Jan Kowalski"));
    }

    [Fact]
    public void OnNewReservation_ShouldFireOnReserve()
    {
        var company = new RentalCompany();
        company.AddVehicle(new Car(1, "Toyota", "Corolla", 2020, "Sedan"));

        string? receivedMessage = null;
        company.OnNewReservation += msg => receivedMessage = msg;

        company.ReserveVehicle(1, "Jan Kowalski");

        Assert.NotNull(receivedMessage);
        Assert.Contains("Jan Kowalski", receivedMessage);
    }
}