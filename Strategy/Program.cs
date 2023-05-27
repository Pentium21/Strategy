public interface IAirportTransport
{
    void GoToAirport();
}
public class CarTransport : IAirportTransport
{
    public void GoToAirport()
    {
        Console.WriteLine("Driving to the airport by car.");
    }
}

public class BusTransport : IAirportTransport
{
    public void GoToAirport()
    {
        Console.WriteLine("Going to the airport by bus.");
    }
}

public class TrainTransport : IAirportTransport
{
    public void GoToAirport()
    {
        Console.WriteLine("Taking the train to the airport.");
    }
}
public class Traveler
{
    private IAirportTransport _transport;

    // Set transport strategy at runtime
    public void SetTransportStrategy(IAirportTransport transport)
    {
        _transport = transport;
    }

    // Go to the airport using the set transport strategy
    public void GoToAirport()
    {
        _transport.GoToAirport();
    }
}
class Program
{
    public static void Main(string[] args)
    {
        var traveler = new Traveler();

        Console.WriteLine("Choose a transport to get to the airport:");
        Console.WriteLine("1. Car");
        Console.WriteLine("2. Bus");
        Console.WriteLine("3. Train");
        Console.Write("Enter the number (1-3): ");

        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                traveler.SetTransportStrategy(new CarTransport());
                break;
            case 2:
                traveler.SetTransportStrategy(new BusTransport());
                break;
            case 3:
                traveler.SetTransportStrategy(new TrainTransport());
                break;
            default:
                Console.WriteLine("Invalid choice. Exiting.");
                return;
        }

        traveler.GoToAirport();
        Console.ReadKey();
    }
}