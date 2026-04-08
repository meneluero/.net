namespace VehicleRental.App;

public class Motorcycle : Vehicle, IReservable
{
    public int EngineCapacity { get; set; }

    public Motorcycle(int id, string brand, string model, int year, int engineCapacity)
        : base(id, brand, model, year)
    {
        EngineCapacity = engineCapacity;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"[Motocykl] ID: {Id} | {Brand} {Model} ({Year}) | " + $"Pojemność silnika: {EngineCapacity}cc | " + $"Dostępny: {(base.IsAvailable ? "Tak" : "Nie")}");
    }

    // jak juz zajety to rzucamy wyjatek, jak wolny to blokujemy
    public void Reserve(string customer)
    {
        if (!base.IsAvailable)
            throw new InvalidOperationException($"Pojazd {Brand} {Model} jest już zarezerwowany.");

        base.IsAvailable = false;
    }

    // zwalniamy pojazd z powrotem do puli
    public void CancelReservation()
    {
        base.IsAvailable = true;
    }

    bool IReservable.IsAvailable() => base.IsAvailable;
}