namespace BusTrackingSimulator.Dtos
{
    using System;

    public class BusInfoDTO
    {
        public string Id { get; set; }
        public int Capacity { get; set; }
        public Location Location { get; set; }
        public int CurrentPassengers { get; set; }
        public TimeSpan TimeToArrival { get; set; }
    }
}
