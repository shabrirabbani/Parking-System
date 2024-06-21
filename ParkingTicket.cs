public class ParkingTicket
{
    public Vehicle ParkedVehicle { get; }
    public DateTime EntryTime { get; }

    public ParkingTicket(Vehicle vehicle)
    {
        ParkedVehicle = vehicle;
        EntryTime = DateTime.Now;
    }
}
