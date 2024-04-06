namespace BusTrackingSimulator.Controllers
{
    using BusTrackingSimulator.Services.Contracts;
    using Microsoft.AspNetCore.Mvc;
    using System;

    [Route("api/[controller]")]
    [ApiController]
    public class BusTrackingController : ControllerBase
    {
        private readonly IBusTrackerService _busTrackerService;

        public BusTrackingController(IBusTrackerService busTrackerService)
        {
            _busTrackerService = busTrackerService;
        }

        [HttpGet]
        public ActionResult GetBusInfo([FromQuery] string busStopId)
        {
            if (string.IsNullOrWhiteSpace(busStopId))
            {
                return BadRequest("Invalid bus stop ID provided.");
            }

            try
            {
                var buses = _busTrackerService.GetUpdatedBusStatus();
                var response = new
                {
                    statusCode = 200,
                    isSuccess = true,
                    errorMessages = new List<string>(),
                    payload = buses.Select(bus => new
                    {
                        id = bus.BusId,
                        location = bus.GetCurrentLocation(),
                        capacity = bus.Capacity,
                        currentPassengers = bus.CurrentPassengers,
                        timeToArrival = bus.TimeToArrival
                    })
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }
    }
}
