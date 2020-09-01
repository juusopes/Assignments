using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;


namespace VSCodeTehtava
{
    class Program
    {
        static async Task Main(string[] args)
        {
            if (args[0] == "realtime")
            {
                RealTimeCityBikeDataFetcher querier = new RealTimeCityBikeDataFetcher();
                Task<int> bikeamount = querier.GetBikeCountInStation(args[1]);
                Console.WriteLine("Waiting results");
                int result = await bikeamount;
            }
            
            else if (args[0] == "offline")
            {
                OfflineCityBikeDataFetcher OfflineQuery = new OfflineCityBikeDataFetcher();
                Task<int> bikeamount2 = OfflineQuery.GetBikeCountInStation(args[0]);
            }
        }
    }
}