using BusTrackingSimulator.Models;

namespace BusTrackingSimulator.Services.Contracts
{
    public interface IBusTrackerService
    {
        List<BusModelGpx> GetUpdatedBusStatus();
    }
}
