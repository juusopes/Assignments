using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

[Serializable()]
public class NotFoundException : System.Exception
{
    public NotFoundException() : base() { }
    public NotFoundException(string message) : base(message) { }
    public NotFoundException(string message, System.Exception inner) : base(message, inner) { }

    // A constructor is needed for serialization when an
    // exception propagates from a remoting server to the client.
    protected NotFoundException(System.Runtime.Serialization.SerializationInfo info,
    System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}

public interface ICityBikeDataFetcher
{
    Task<int> GetBikeCountInStation(string stationName);
}

public class RealTimeCityBikeDataFetcher : ICityBikeDataFetcher
{
    // Task<int> bikeCount;
    public async Task<int> GetBikeCountInStation(string stationName)
    {
        HttpClient bikeamountstringretriever = new HttpClient();

        try
        {


            string responseBody = await bikeamountstringretriever.GetStringAsync("https://api.digitransit.fi/routing/v1/routers/hsl/bike_rental");

            foreach (char c in stationName)
            {
                if (char.IsDigit(c))
                {
                    System.ArgumentException argEx = new System.ArgumentException("Contains numbers");
                    throw argEx;
                }
            }
            // Console.WriteLine(responseBody);

            BikeRentalStationList bikes = JsonConvert.DeserializeObject<BikeRentalStationList>(responseBody);
            for (int i = 0; i < bikes.stations.Length; i++)
            {
                if (bikes.stations[i].name == stationName)
                {
                    int bikeCount = Convert.ToInt32(bikes.stations[i].bikesAvailable);
                    Console.WriteLine("there are " + bikeCount + " bikes at the station");
                    return 1;
                }
            }

            System.Exception argEx2 = new NotFoundException();
            throw argEx2;
        }
        
        catch (NotFoundException exx)
        {
            Console.WriteLine("Object not found", exx.Message);
        }
        catch (System.IndexOutOfRangeException exx)
        {
            Console.WriteLine("Please provide at least one argument", exx.Message);
        }
        catch (System.FormatException e)
        {
            Console.WriteLine("That is not a letter!", e.Message);
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine("\nException Caught!");
            Console.WriteLine("Message :{0} ", ex.Message);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Invalid argument: "+ ex.Message);
        }
        catch (System.Exception ex)
        {
            Console.WriteLine("We caught something else", ex.Message);
        }

        return 1;
    }
}