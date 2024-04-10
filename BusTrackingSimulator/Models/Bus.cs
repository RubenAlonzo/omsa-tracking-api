namespace BusTrackingSimulator.Models
{
    using BusTrackingSimulator.Dtos;

    public class Bus
    {
        public int BusId { get; set; }
        public int Capacity { get; set; }
        public int CurrentPassengers { get; set; }
        // CurrentStopIndex to track which bus stop the bus is currently at
        public int CurrentStopIndex { get; set; }

        // Method to update the current location of the bus
        public Location GetCurrentLocation(List<BusStopDTO> busStops)
        {
            if (busStops == null || !busStops.Any() || CurrentStopIndex >= busStops.Count)
            {
                throw new InvalidOperationException("Invalid bus stop index or bus stops list.");
            }
            return busStops[CurrentStopIndex].Location;
        }

        // Update to next bus stop
        public void UpdateToNextStop(int totalStops)
        {
            CurrentStopIndex = (CurrentStopIndex + 1) % totalStops;
        }
    }
}
