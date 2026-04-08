namespace VehicleRental.App;

public class Car : Vehicle, IReservable
{
    public string BodyType { get; set; }

    public Car(int id, string brand, string model, int year, string bodyType)
        : base(id, brand, model, year)
    {
        BodyType = bodyType;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"[Samochód] ID: {Id} | {Brand} {Model} ({Year}) | " + $"Typ nadwozia: {BodyType} | " + $"Dostępny: {(base.IsAvailable ? "Tak" : "Nie")}");
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