namespace VehicleRental.App;

public static class VehicleExtensions
{
    // filtrujemy liste i zwracamy tylko wolne pojazdy
    public static List<Vehicle> GetAvailableVehicles(this List<Vehicle> vehicles)
    {
        return vehicles.Where(v => v.IsAvailable).ToList();
    }
}