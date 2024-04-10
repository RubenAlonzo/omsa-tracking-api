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
        private readonly IBusService _busService;

        public BusTrackingController(IBusTrackerService busTrackerService, IBusService busService)
        {
            _busTrackerService = busTrackerService;
            _busService = busService;
        }

        [HttpGet("/api/bus-stops")]
        public ActionResult GetBusStops([FromQuery] string busStopName)
        {
            if (string.IsNullOrWhiteSpace(busStopName))
            {
                return BadRequest("Invalid bus stop ID provided.");
            }

            try
            {
                _busService.UpdateBusLocations(int.Parse(busStopName));
                var response = new ResponseDTO<List<BusStopDTO>>
                {
                    StatusCode = "200",
                    IsSuccess = true,
                    ErrorMessages = new List<string>(),
                    Payload = _busService.GetBusStops()
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("/api/toggle-favorite")] // TODO: Change to PUT and DELETE
        public ActionResult ToggleFavorite([FromQuery] int busStopId)
        {
            if (busStopId <= 0)
            {
                return BadRequest("Invalid bus stop ID provided.");
            }

            try
            {
                var response = new ResponseDTO<bool>
                {
                    StatusCode = "200",
                    IsSuccess = true,
                    ErrorMessages = new List<string>(),
                    Payload = _busService.ToggleFavoriteStatus(busStopId)
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
