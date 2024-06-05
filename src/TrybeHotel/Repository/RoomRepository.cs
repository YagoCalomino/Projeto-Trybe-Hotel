using TrybeHotel.Models;
using TrybeHotel.Dto;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace TrybeHotel.Repository
{
    public class RoomRepository : IRoomRepository
    {
        protected readonly ITrybeHotelContext _context;
        public RoomRepository(ITrybeHotelContext context)
        {
            _context = context;
        }

        // 6. Desenvolva o endpoint GET /room/:hotelId
        public IEnumerable<RoomDto> GetRooms(int HotelId)
        {
            var hotelEncontrado = _context.Hotels.Include(h => h.City).Include(h => h.Rooms)
                .FirstOrDefault(h => h.HotelId == HotelId);

            var listaDeQuartos = hotelEncontrado!.Rooms!.Select(r => new RoomDto
            {
                roomId = r.RoomId,
                name = r.Name,
                capacity = r.Capacity,
                image = r.Image,
                hotel = new HotelDto
                {
                    hotelId = hotelEncontrado.HotelId,
                    name = hotelEncontrado.Name,
                    address = hotelEncontrado.Address,
                    cityId = hotelEncontrado.CityId,
                    cityName = hotelEncontrado.City!.Name,
                }
            }).ToList();

            return listaDeQuartos;
        }

        // 7. Desenvolva o endpoint POST /room
        public RoomDto AddRoom(Room room)
        {
            var hotelAssociado = _context.Hotels.Include(h => h.City).FirstOrDefault(h => h.HotelId == room.HotelId);

            var quartoAdicionado = _context.Rooms.Add(room).Entity;
            _context.SaveChanges();

            return new RoomDto
            {
                roomId = quartoAdicionado.RoomId,
                name = quartoAdicionado.Name,
                capacity = quartoAdicionado.Capacity,
                image = quartoAdicionado.Image,
                hotel = new HotelDto
                {
                    hotelId = hotelAssociado!.HotelId,
                    name = hotelAssociado.Name,
                    address = hotelAssociado.Address,
                    cityId = hotelAssociado.CityId,
                    cityName = hotelAssociado.City!.Name
                }
            };
        }

        // 8. Desenvolva o endpoint DELETE /room/:roomId
        public void DeleteRoom(int RoomId)
        {            
            var quartoEncontrado = _context.Rooms.Find(RoomId);

            _context.Rooms.Remove(quartoEncontrado!);
            _context.SaveChanges();
        }
    }
}