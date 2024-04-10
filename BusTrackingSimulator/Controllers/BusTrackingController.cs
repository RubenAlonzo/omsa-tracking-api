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
        public ActionResult GetBusStops([FromQuery] string busStopId)
        {
            if (string.IsNullOrWhiteSpace(busStopId))
            {
                return BadRequest("Invalid bus stop ID provided.");
            }

            try
            {
                _busService.UpdateBusLocations();
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
                var response = new ResponseDTO<List<BusStopDTO>>
                {
                    StatusCode = "200",
                    IsSuccess = true,
                    ErrorMessages = new List<string>(),
                    Payload = new List<BusStopDTO>
                    {
                        new BusStopDTO()
                        {
                            Id = 333,
                            Name = "Av. 27 de Febrero Proximo Av. Maximo Gomez",
                            IsFavorite = false,
                            Location = new Location() { Latitude = 18.480996938618595, Longitude = -69.9148515636799 },
                            Buses = buses.Select(bus => new BusInfoDTO
                            {
                                Id = bus.BusId,
                                Location = bus.GetCurrentLocation(),
                                Capacity = bus.Capacity,
                                CurrentPassengers = bus.CurrentPassengers,
                                TimeToArrival = bus.TimeToArrival
                            }).ToList()
                        },
                        new BusStopDTO()
                        {
                            Id = 1,
                            Name = "Av. 28 de Febrero Proximo Av. Maximo Gomez",
                            IsFavorite = true,
                            Location = new Location() { Latitude = 18.480996938618595, Longitude = -69.9148515636799 },
                            Buses = buses.Select(bus => new BusInfoDTO
                            {
                                Id = bus.BusId,
                                Location = bus.GetCurrentLocation(),
                                Capacity = bus.Capacity,
                                CurrentPassengers = bus.CurrentPassengers,
                                TimeToArrival = bus.TimeToArrival
                            }).ToList()
                        },
                        new BusStopDTO()
                        {
                            Id = 22,
                            Name = "Av. 29 de Febrero Proximo Av. Maximo Gomez",
                            IsFavorite = true,
                            Location = new Location() { Latitude = 18.480996938618595, Longitude = -69.9148515636799 },
                            Buses = buses.Select(bus => new BusInfoDTO
                            {
                                Id = bus.BusId,
                                Location = bus.GetCurrentLocation(),
                                Capacity = bus.Capacity,
                                CurrentPassengers = bus.CurrentPassengers,
                                TimeToArrival = bus.TimeToArrival
                            }).ToList()
                        },
                        new BusStopDTO()
                        {
                            Id = 452,
                            Name = "Av. 29 de Febrero Proximo Av. Maximo Gomez",
                            IsFavorite = false,
                            Location = new Location() { Latitude = 18.480996938618595, Longitude = -69.9148515636799 },
                            Buses = buses.Select(bus => new BusInfoDTO
                            {
                                Id = bus.BusId,
                                Location = bus.GetCurrentLocation(),
                                Capacity = bus.Capacity,
                                CurrentPassengers = bus.CurrentPassengers,
                                TimeToArrival = bus.TimeToArrival
                            }).ToList()
                        },
                    }
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
