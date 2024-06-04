namespace TrybeHotel.Dto
{
    public class HotelDto
    {
        private int _hotelId;
        public int hotelId 
        {
            get { return _hotelId; }
            set { _hotelId = value; }
        }
        public string? name { get; set; }
        public string? address { get; set; }
        public int cityId { get; set; }
        public string? cityName { get; set; }
    }
}