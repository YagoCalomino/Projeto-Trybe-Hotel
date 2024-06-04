namespace TrybeHotel.Dto
{
    public class CityDto
    {
        private int _cityId;
        public int cityId 
        {
            get { return _cityId; }
            set { _cityId = value; }
        }
        public string? name { get; set; }
    }
}
