namespace VehicleRental.App;

public class Reservation
{
    public int ReservationId { get; set; }
    public Vehicle ReservedVehicle { get; set; }
    public string Customer { get; set; }
    public DateTime ReservationDate { get; set; }

    public Reservation(int reservationId, Vehicle reservedVehicle, string customer)
    {
        ReservationId = reservationId;
        ReservedVehicle = reservedVehicle;
        Customer = customer;
        ReservationDate = DateTime.Now;
    }

    public override string ToString()
    {
        return $"Rezerwacja #{ReservationId} | Klient: {Customer} | " + $"Pojazd: {ReservedVehicle.Brand} {ReservedVehicle.Model} | " + $"Data: {ReservationDate:dd.MM.yyyy HH:mm}";
    }
}