namespace BusTrackingSimulator.Dtos
{
    public class BusStopDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsFavorite { get; set; }
        public Location Location { get; set; }
        public List<BusInfoDTO> Buses { get; set; }
    }
}
