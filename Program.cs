using System;

class Program
{
    static void Main(string[] args)
    {
        ParkingLot parkingLot = null;
        bool exit = false;

        Console.WriteLine("Welcome to Parking System");
        Console.WriteLine("Commands:");

        while (!exit)
        {
            string input = Console.ReadLine().Trim();
            string[] parts = input.Split(' ');

            string command = parts[0].ToLower();

            switch (command)
            {
                case "create_parking_lot":
                    int capacity = int.Parse(parts[1]);
                    parkingLot = new ParkingLot(capacity);
                    Console.WriteLine($"Created a parking lot with {capacity} slots");
                    break;

                case "park":
                    string regNumber = parts[1];
                    string color = parts[2];
                    string vehicleType = parts[3].ToLower();
                    Vehicle vehicle = new Vehicle(regNumber, color, vehicleType);

                    if (parkingLot != null)
                    {
                        parkingLot.ParkVehicle(vehicle);
                    }
                    break;

                case "leave":
                    int slotNumber = int.Parse(parts[1]);
                    if (parkingLot != null)
                    {
                        parkingLot.Leave(slotNumber);
                    }
                    break;

                case "status":
                    if (parkingLot != null)
                    {
                        parkingLot.Status();
                    }
                    break;

                case "type_of_vehicles":
                    string vehicleTypeQuery = parts[1].ToLower();
                    int count = parkingLot.CountVehiclesByType(vehicleTypeQuery);
                    Console.WriteLine($"{count}");
                    break;

                case "registration_numbers_for_vehicles_with_ood_plate":
                    if (parkingLot != null)
                    {
                        parkingLot.RegistrationNumbersForVehiclesWithOddPlate();
                    }
                    break;

                case "registration_numbers_for_vehicles_with_even_plate":
                    if (parkingLot != null)
                    {
                        parkingLot.RegistrationNumbersForVehiclesWithEvenPlate();
                    }
                    break;
                
                case "registration_numbers_for_vehicles_with_colour":
                    string colorQuery = parts[1].ToLower();
                    if (parkingLot != null)
                    {
                        parkingLot.RegistrationNumbersForVehiclesWithColor(colorQuery);
                    }
                    break;

                case "slot_numbers_for_vehicles_with_colour":
                    string colorQuery2 = parts[1].ToLower();
                    if (parkingLot != null)
                    {
                        parkingLot.SlotNumbersForVehiclesWithColor(colorQuery2);
                    }
                    break;

                case "slot_number_for_registration_number":
                    string regNumberQuery = parts[1];
                    if (parkingLot != null)
                    {
                        parkingLot.SlotNumberForRegistrationNumber(regNumberQuery);
                    }
                    break;

                case "exit":
                    exit = true;
                    break;

                default:
                    Console.WriteLine("Invalid command");
                    break;
            }
        }
    }
}
