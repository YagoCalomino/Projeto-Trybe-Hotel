namespace TrybeHotel.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// 1. Implemente as models da aplicação
public class Hotel
{
    [Key]
    public int HotelId { get; set; }
    public string? Name { get; set; }
    public string? Address { get; set; }
    [ForeignKey("CityId")]
    public int CityId { get; set; }
    private ICollection<Room>? _rooms;
    public ICollection<Room>? Rooms 
    { 
        get { return _rooms; } 
        set { _rooms = value; }
    }
    public City? City { get; set; }
}

