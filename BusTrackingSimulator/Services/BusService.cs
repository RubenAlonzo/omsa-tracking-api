namespace BusTrackingSimulator.Services
{
    using BusTrackingSimulator.Dtos;
    using BusTrackingSimulator.Models;
    using BusTrackingSimulator.Services.Contracts;

    public class BusService : IBusService
    {
        private List<BusStopDTO> busStops;
        private List<Bus> buses;

        private const string GpxBusStopsFeb =
""""
<?xml version="1.0" encoding="UTF-8" standalone="no" ?>
<gpx version="1.1" creator="http://www.geoplaner.com" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns="http://www.topografix.com/GPX/1/1" xsi:schemaLocation="http://www.topografix.com/GPX/1/1 http://www.topografix.com/GPX/1/1/gpx.xsd">
<rte>
<name>Route1</name>
<rtept lat="18.47595" lon="-69.90744">
<name>WP01-A</name>
</rtept>
<rtept lat="18.47572" lon="-69.91538">
<name>WP02-B</name>
</rtept>
<rtept lat="18.47306" lon="-69.91905">
<name>WP03-C</name>
</rtept>
<rtept lat="18.46754" lon="-69.92695">
<name>WP04-D</name>
</rtept>
</rte>
</gpx>
"""";
        private const string GpxBusStopsGomez =
""""
<?xml version="1.0" encoding="UTF-8" standalone="no" ?>
<gpx version="1.1" creator="http://www.geoplaner.com" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns="http://www.topografix.com/GPX/1/1" xsi:schemaLocation="http://www.topografix.com/GPX/1/1 http://www.topografix.com/GPX/1/1/gpx.xsd">
<rte>
<name>Route1</name>
<rtept lat="18.4646" lon="-69.90981">
<name>WP01-A</name>
</rtept>
<rtept lat="18.4667" lon="-69.91084">
<name>WP02-B</name>
</rtept>
<rtept lat="18.47021" lon="-69.91192">
<name>WP03-C</name>
</rtept>
<rtept lat="18.47583" lon="-69.91324">
<name>WP04-D</name>
</rtept>
<rtept lat="18.48138" lon="-69.91412">
<name>WP05-E</name>
</rtept>
</rte>
</gpx>
"""";
        private const string GpxBusStopsImg =
""""
<?xml version="1.0" encoding="UTF-8" standalone="no" ?>
<gpx version="1.1" creator="http://www.geoplaner.com" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns="http://www.topografix.com/GPX/1/1" xsi:schemaLocation="http://www.topografix.com/GPX/1/1 http://www.topografix.com/GPX/1/1/gpx.xsd">
<rte>
<name>Route1</name>
<rtept lat="18.47629" lon="-69.91354">
<name>WP01-A</name>
</rtept>
<rtept lat="18.47507" lon="-69.91637">
<name>WP02-B</name>
</rtept>
<rtept lat="18.47271" lon="-69.9192">
<name>WP03-C</name>
</rtept>
<rtept lat="18.46921" lon="-69.92332">
<name>WP04-D</name>
</rtept>
<rtept lat="18.46701" lon="-69.92795">
<name>WP05-E</name>
</rtept>
<rtept lat="18.46489" lon="-69.93224">
<name>WP06-F</name>
</rtept>
<rtept lat="18.4627" lon="-69.9355">
<name>WP07-G</name>
</rtept>
<rtept lat="18.45919" lon="-69.93276">
<name>WP08-H</name>
</rtept>
<rtept lat="18.45561" lon="-69.93078">
<name>WP09-I</name>
</rtept>
<rtept lat="18.45333" lon="-69.92889">
<name>WP10-J</name>
</rtept>
<rtept lat="18.45097" lon="-69.92726">
<name>WP11-K</name>
</rtept>
<rtept lat="18.44763" lon="-69.92546">
<name>WP12-L</name>
</rtept>
<rtept lat="18.44926" lon="-69.92323">
<name>WP13-M</name>
</rtept>
<rtept lat="18.45358" lon="-69.91997">
<name>WP14-N</name>
</rtept>
<rtept lat="18.45496" lon="-69.91697">
<name>WP15-O</name>
</rtept>
<rtept lat="18.45643" lon="-69.9138">
<name>WP16-P</name>
</rtept>
<rtept lat="18.45789" lon="-69.90882">
<name>WP17-Q</name>
</rtept>
<rtept lat="18.45944" lon="-69.90702">
<name>WP18-R</name>
</rtept>
<rtept lat="18.46237" lon="-69.90865">
<name>WP19-S</name>
</rtept>
<rtept lat="18.4653" lon="-69.91028">
<name>WP20-T</name>
</rtept>
<rtept lat="18.46864" lon="-69.91156">
<name>WP21-U</name>
</rtept>
<rtept lat="18.47263" lon="-69.91268">
<name>WP22-V</name>
</rtept>
</rte>
</gpx>
"""";

        public BusService()
        {

            // Initialize your bus stops and buses here
            // For demonstration, bus stops will be manually added as per your payload
            // Normally, you would parse a GPX file to get these locations
            busStops = new List<BusStopDTO>();
            var busStops1 = GpxParser.ParseRoute(GpxBusStopsImg);
            foreach (var stop in busStops1)
            {
                busStops.Add(new BusStopDTO { Id = busStops.Count + 1, IsFavorite = false, Name = $"bus stop {busStops.Count + 1}", Location = new Location { Latitude = stop.Latitude, Longitude = stop.Longitude } });
            }

            buses = new List<Bus>
            {
                // Initialize your buses here
                new Bus { BusId = 111, Capacity = 50, CurrentPassengers = 11, CurrentStopIndex = 0 },
                new Bus { BusId = 222, Capacity = 50, CurrentPassengers = 22, CurrentStopIndex = 2 },
                new Bus { BusId = 333, Capacity = 50, CurrentPassengers = 33, CurrentStopIndex = 4 },
            };

            // Optionally initialize each bus with a random bus stop location
            Random rnd = new Random();
            foreach (var bus in buses)
            {
                bus.CurrentStopIndex = rnd.Next(busStops.Count);
            }
        }

        public void UpdateBusLocations()
        {
            foreach (var bus in buses)
            {
                bus.UpdateToNextStop(busStops.Count);
            }

            // Update the buses for each bus stop based on the new locations
            foreach (var stop in busStops)
            {
                stop.Buses = buses.Where(b => b.GetCurrentLocation(busStops).Latitude == stop.Location.Latitude &&
                                              b.GetCurrentLocation(busStops).Longitude == stop.Location.Longitude)
                                  .Select(b => new BusInfoDTO
                                  {
                                      Id = b.BusId.ToString(),
                                      Location = b.GetCurrentLocation(busStops),
                                      Capacity = b.Capacity,
                                      CurrentPassengers = b.CurrentPassengers,
                                      // Placeholder for TimeToArrival calculation
                                      TimeToArrival = TimeSpan.FromMinutes(5) // Example value
                                  }).ToList();
            }
        }

        public List<BusStopDTO> GetBusStops()
        {
            return busStops;
        }

    }
}
