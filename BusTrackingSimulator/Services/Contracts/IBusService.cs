namespace BusTrackingSimulator.Services.Contracts
{
    using BusTrackingSimulator.Dtos;
    using System.Collections.Generic;

    public interface IBusService
    {
        List<BusStopDTO> GetBusStops();
        void UpdateBusLocations(int targetBusStopId);
    }
}