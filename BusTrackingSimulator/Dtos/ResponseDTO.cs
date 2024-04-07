namespace BusTrackingSimulator.Dtos
{
    public class ResponseDTO<T>
    {
        public string StatusCode { get; set; }
        public bool IsSuccess { get; set; }
        public List<string> ErrorMessages { get; set; }
        public T Payload { get; set; }
    }
}
