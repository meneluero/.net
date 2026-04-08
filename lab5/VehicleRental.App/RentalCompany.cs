namespace VehicleRental.App;

public class RentalCompany
{
    private List<Vehicle> vehicles = new();
    private List<Reservation> reservations = new();

    // bedziemy inkrementowac przy kazdej nowej rezerwacji
    private int nextReservationId = 1;

    // event - kto sie zapisze, dostanie powiadomienie o nowej rezerwacji
    public event Action<string>? OnNewReservation;

    public void AddVehicle(Vehicle vehicle)
    {
        vehicles.Add(vehicle);
        Console.WriteLine($"Dodano pojazd: {vehicle.Brand} {vehicle.Model}");
    }

    public void ReserveVehicle(int vehicleId, string customer)
    {
        var vehicle = vehicles.FirstOrDefault(v => v.Id == vehicleId)
            ?? throw new ArgumentException($"Nie znaleziono pojazdu o ID: {vehicleId}");

        if (vehicle is not IReservable reservable)
            throw new InvalidOperationException("Ten pojazd nie obsługuje rezerwacji.");

        reservable.Reserve(customer);

        var reservation = new Reservation(nextReservationId++, vehicle, customer);
        reservations.Add(reservation);

        OnNewReservation?.Invoke(
            $"Nowa rezerwacja! {reservation}");
    }

    public void CancelReservation(int reservationId)
    {
        var reservation = reservations.FirstOrDefault(r => r.ReservationId == reservationId)
            ?? throw new ArgumentException($"Nie znaleziono rezerwacji o ID: {reservationId}");

        if (reservation.ReservedVehicle is IReservable reservable)
            reservable.CancelReservation();

        reservations.Remove(reservation);
        Console.WriteLine($"Anulowano rezerwację #{reservationId} " + $"({reservation.ReservedVehicle.Brand} {reservation.ReservedVehicle.Model})");
    }

    public void ListAvailableVehicles()
    {
        // tu uzywa metody rozszerzajacej zamiast pisac where recznie
        var available = vehicles.GetAvailableVehicles();

        Console.WriteLine("\nDostępne pojazdy:");
        if (!available.Any())
        {
            Console.WriteLine("Brak dostępnych pojazdów.");
            return;
        }

        // dla kazdego pojazdu wywolaj displayinfo
        available.ForEach(v => v.DisplayInfo());
    }

    public List<Vehicle> GetAllVehicles() => vehicles;

    public List<Reservation> GetAllReservations() => reservations;
}