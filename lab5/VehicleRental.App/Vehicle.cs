namespace VehicleRental.App;

// abstrakcyjna klasa bazowa dla wszystkich pojazdow
public abstract class Vehicle
{
    public int Id { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    
    // true = pojazd mozliwy do zarezerwowania
    public bool IsAvailable { get; set; } = true;

    protected Vehicle(int id, string brand, string model, int year)
    {
        Id = id;
        Brand = brand;
        Model = model;
        Year = year;
    }

    public abstract void DisplayInfo();
}