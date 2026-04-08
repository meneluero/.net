using VehicleRental.App;

Console.WriteLine("System Zarządzania Rezerwacjami Pojazdów\n");

var rentalCompany = new RentalCompany();

rentalCompany.OnNewReservation += message => Console.WriteLine(message);

// dodawanie pojazdow
rentalCompany.AddVehicle(new Car(1, "Toyota", "Corolla", 2020, "Sedan"));
rentalCompany.AddVehicle(new Car(2, "BMW", "X5", 2022, "SUV"));
rentalCompany.AddVehicle(new Motorcycle(3, "Yamaha", "MT-07", 2021, 689));
rentalCompany.AddVehicle(new Motorcycle(4, "Honda", "CBR600RR", 2023, 600));

// lista dostepnych pojazdow przed rezerwacja
rentalCompany.ListAvailableVehicles();

// rezerwacje
Console.WriteLine();
rentalCompany.ReserveVehicle(1, "Jan Kowalski");
rentalCompany.ReserveVehicle(3, "Anna Nowak");

// lista po rezerwacjach
rentalCompany.ListAvailableVehicles();

// anulowanie rezerwacji
Console.WriteLine();
rentalCompany.CancelReservation(1);
rentalCompany.ListAvailableVehicles();

// testujemy co sie stanie jak sprobujemy zarezerwowac juz zajety pojazd
Console.WriteLine("\nTest podwójnej rezerwacji");
try
{
    rentalCompany.ReserveVehicle(3, "Piotr Wiśniewski");
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Błąd: {ex.Message}");
}