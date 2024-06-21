public class Vehicle
{
    public string RegistrationNumber { get; }
    public string Color { get; }
    public string Type { get; } // Changed type to string

    public Vehicle(string regNumber, string color, string type)
    {
        RegistrationNumber = regNumber;
        Color = color;
        Type = type;
    }
}
