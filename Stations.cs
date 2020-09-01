using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

    public class Stations
    {   
        public int stationId { get; set; }
        public string name { get; set; }
        public float x { get; set; }
        public float y { get; set; }
        public int bikesAvailable { get; set; }
        public int spacesAvailable { get; set; }
        public bool allowDropoff { get; set; }
        public bool isFloatingBike { get; set; }
        public bool isCarStation { get; set; }
        public string stationOn { get; set; }
        public string[] networks { get; set; }
        public bool realTimeData { get; set; }
    }