namespace VehicleRental.App;

public interface IReservable
{
    // rezerwuje pojazd na danego klienta
    void Reserve(string customer);
    
    void CancelReservation();

    // sprawdza czy mozna zarezerwowac
    bool IsAvailable();
}