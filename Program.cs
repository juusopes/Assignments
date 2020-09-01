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
            OfflineCityBikeDataFetcher OfflineQuery = new OfflineCityBikeDataFetcher();
            Task<int> bikeamount2 = OfflineQuery.GetBikeCountInStation(args[0]);

            RealTimeCityBikeDataFetcher querier = new RealTimeCityBikeDataFetcher();
            Task<int> bikeamount = querier.GetBikeCountInStation(args[0]);
            Console.WriteLine("Waiting results");
            int result = await bikeamount;
        }

    }
}