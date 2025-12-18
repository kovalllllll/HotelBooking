using HotelBooking.Domain.Entities;

namespace HotelBooking.Application.Interfaces;

public interface IHotelRepository : IRepository<Hotel>
{
    Task<IEnumerable<Hotel>> GetHotelsByCityAsync(string city);
    Task<Hotel?> GetHotelWithRoomsAsync(int id);
    Task<IEnumerable<Hotel>> GetAllWithRoomsAsync();
}

