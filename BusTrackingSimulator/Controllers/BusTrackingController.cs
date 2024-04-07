namespace BusTrackingSimulator.Controllers
{
    using BusTrackingSimulator.Dtos;
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
                //var response = new
                //{
                //    statusCode = 200,
                //    isSuccess = true,
                //    errorMessages = new List<string>(),
                //    payload = buses.Select(bus => new
                //    {
                //        id = bus.BusId,
                //        location = bus.GetCurrentLocation(),
                //        capacity = bus.Capacity,
                //        currentPassengers = bus.CurrentPassengers,
                //        timeToArrival = bus.TimeToArrival
                //    })
                //};
                
                var response = new ResponseDTO<List<BusInfoDTO>>
                {
                    StatusCode = "200",
                    IsSuccess = true,
                    ErrorMessages = new List<string>(),
                    Payload = buses.Select(bus => new BusInfoDTO
                    {
                        Id = bus.BusId,
                        Location = bus.GetCurrentLocation(),
                        Capacity = bus.Capacity,
                        CurrentPassengers = bus.CurrentPassengers,
                        TimeToArrival = bus.TimeToArrival
                    }).ToList()
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
