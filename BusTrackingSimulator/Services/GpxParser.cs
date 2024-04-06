namespace BusTrackingSimulator.Services
{
    using System.Xml.Linq;

    public static class GpxParser
    {
        public static List<(double Latitude, double Longitude)> ParseRoute(string gpxData)
        {
            XDocument gpxDoc = XDocument.Parse(gpxData);
            XNamespace gpx = "http://www.topografix.com/GPX/1/1";

            var waypoints = new List<(double, double)>();
            foreach (var wp in gpxDoc.Descendants(gpx + "rtept"))
            {
                double lat = (double)wp.Attribute("lat");
                double lon = (double)wp.Attribute("lon");
                waypoints.Add((lat, lon));
            }

            return waypoints;
        }
    }
}
