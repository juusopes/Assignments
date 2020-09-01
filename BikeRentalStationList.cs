using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

    public class BikeRentalStationList
    { 
        public Stations[] stations { get; set; }
        public BikeRentalStationList(Stations[] staton)
        {
            stations = staton;
            //stationName=stationname;
        }
    }