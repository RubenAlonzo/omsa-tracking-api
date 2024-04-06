namespace BusTrackingSimulator.Models
{
    using System;

    public class Bus
    {
        public string BusId { get; set; }
        public List<(double Latitude, double Longitude)> Route { get; set; }
        public int CurrentRouteIndex { get; set; } = 0;
        public int Capacity { get; set; }
        public int CurrentPassengers { get; set; }
        public TimeSpan TimeToArrival { get; set; }

        public object GetCurrentLocation()
        {
            var location = CurrentRouteIndex >= Route.Count ? Route.LastOrDefault() : Route[CurrentRouteIndex];
            return new { latitude = location.Latitude, longitude = location.Longitude };
        }
    }
}
