using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.IO; 

public interface OfflineICityBikeDataFetcher
{
    Task<int> GetBikeCountInStation(string stationName);
}

public class OfflineCityBikeDataFetcher : ICityBikeDataFetcher
{   
    public async Task<int> GetBikeCountInStation(string stationName)
    {
        string text = System.IO.File.ReadAllText(@"C:\Users\Juuso\Desktop\bikedata.txt");
        System.Console.WriteLine("Contents of bikedata.txt = {0}", text);

        return 1;
    }
}