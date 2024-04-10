namespace BusTrackingSimulator.Services.Contracts
{
    using BusTrackingSimulator.Dtos;
    using System.Collections.Generic;

    public interface IBusService
    {
        List<BusStopDTO> GetBusStops();
        bool ToggleFavoriteStatus(int busStopId);
        void UpdateBusLocations(int targetBusStopId);
    }
}