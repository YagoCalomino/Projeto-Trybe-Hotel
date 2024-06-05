using TrybeHotel.Models;
using TrybeHotel.Dto;

namespace TrybeHotel.Repository
{
    public class HotelRepository : IHotelRepository
    {
        protected readonly ITrybeHotelContext _context;
        public HotelRepository(ITrybeHotelContext context)
        {
            _context = context;
        }

        // 4. Desenvolva o endpoint GET /hotel
        public IEnumerable<HotelDto> GetHotels()
        {
        var allHotels = _context.Hotels
            .Select(h => new HotelDto
            {
                hotelId = h.HotelId,
                name = h.Name,
                address = h.Address,
                cityId = h.CityId,
                cityName = h.City!.Name
            }).ToList();

        return allHotels;     
        }
        
        // 5. Desenvolva o endpoint POST /hotel
        public HotelDto AddHotel(Hotel hotel)
        {
            var hotelAdicionado = _context.Hotels.Add(hotel).Entity;
            _context.SaveChanges();

            var cidade = _context.Cities.SingleOrDefault(c => c.CityId == hotelAdicionado.CityId);

            return new HotelDto
            {
                hotelId = hotelAdicionado.HotelId,
                name = hotelAdicionado.Name,
                address = hotelAdicionado.Address,
                cityId = hotelAdicionado.CityId,
                cityName = cidade?.Name
            };
        }
    }
}