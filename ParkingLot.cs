using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


public class ParkingLot
{
    private int _capacity;
    private Dictionary<int, ParkingTicket> _parkingSlots;

    public ParkingLot(int capacity)
    {
        _capacity = capacity;
        _parkingSlots = new Dictionary<int, ParkingTicket>();
    }

    public bool ParkVehicle(Vehicle vehicle)
    {
        // Find first available slot
        int slotNumber = FindFirstAvailableSlot();
        if (slotNumber == -1)
        {
            Console.WriteLine("Sorry, parking lot is full");
            return false;
        }

        // Park the vehicle in the slot
        _parkingSlots[slotNumber] = new ParkingTicket(vehicle);
        Console.WriteLine($"Allocated slot number: {slotNumber}");
        return true;
    }

    public void Leave(int slotNumber)
    {
        if (_parkingSlots.ContainsKey(slotNumber))
        {
            _parkingSlots.Remove(slotNumber);
            Console.WriteLine($"Slot number {slotNumber} is free");
        }
        else
        {
            Console.WriteLine($"Slot number {slotNumber} is already free");
        }
    }

    public void Status()
    {
        Console.WriteLine("Slot\tNo.\tType\tRegistration No\tColour");
        foreach (var kvp in _parkingSlots.OrderBy(kv => kv.Key))
        {
            int slotNumber = kvp.Key;
            var ticket = kvp.Value;
            Console.WriteLine($"{slotNumber}\t{ticket.ParkedVehicle.RegistrationNumber}\t" +
                              $"{ticket.ParkedVehicle.Type}\t{ticket.ParkedVehicle.Color}");
        }
    }

    public int CountVehiclesByType(string type)
    {
        return _parkingSlots.Values.Count(ticket => ticket.ParkedVehicle.Type.ToLower() == type.ToLower());
    }

    private int GetNumericPart(string registrationNumber)
    {
        string numericPart = registrationNumber.Split('-')[1];
        numericPart = new string(numericPart.Where(char.IsDigit).ToArray());
        return int.Parse(numericPart);
    }

    public void RegistrationNumbersForVehiclesWithOddPlate()
    {
        var oddPlates = _parkingSlots.Values
        .Where(ticket => IsOddNumber(GetNumericPart(ticket.ParkedVehicle.RegistrationNumber)))
        .Select(ticket => ticket.ParkedVehicle.RegistrationNumber);
    
        Console.WriteLine(string.Join(", ", oddPlates));
    }

    public void RegistrationNumbersForVehiclesWithEvenPlate()
    {
        var evenPlates = _parkingSlots.Values
        .Where(ticket => IsEvenNumber(GetNumericPart(ticket.ParkedVehicle.RegistrationNumber)))
        .Select(ticket => ticket.ParkedVehicle.RegistrationNumber);
    
        Console.WriteLine(string.Join(", ", evenPlates));
    }

    private bool IsOddNumber(int number)
    {
        return number % 2 != 0;
    }

    private bool IsEvenNumber(int number)
    {
        return number % 2 == 0;
    }

    public void SlotNumbersForVehiclesWithColor(string color)
    {
        var slots = _parkingSlots.Where(kv => kv.Value.ParkedVehicle.Color.ToLower() == color.ToLower())
            .Select(kv => kv.Key);
        Console.WriteLine(string.Join(", ", slots));
    }

    public void RegistrationNumbersForVehiclesWithColor(string color)
    {
        var regNumbers = _parkingSlots.Where(kv => kv.Value.ParkedVehicle.Color.ToLower() == color.ToLower())
            .Select(kv => kv.Value.ParkedVehicle.RegistrationNumber);
        Console.WriteLine(string.Join(", ", regNumbers));
    }

    public void SlotNumberForRegistrationNumber(string registrationNumber)
    {
        var slotNumber = _parkingSlots.FirstOrDefault(slot => slot.Value.ParkedVehicle.RegistrationNumber.Equals(registrationNumber, StringComparison.OrdinalIgnoreCase)).Key;

        if (slotNumber == 0)
        {
            Console.WriteLine("Not found");
        }
        else
        {
            Console.WriteLine(slotNumber);
        }
    }


    private int FindFirstAvailableSlot()
    {
        for (int i = 1; i <= _capacity; i++)
        {
            if (!_parkingSlots.ContainsKey(i))
            {
                return i;
            }
        }
        return -1; // Parking lot is full
    }
}
