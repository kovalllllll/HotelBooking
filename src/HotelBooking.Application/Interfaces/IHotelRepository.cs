using HotelBooking.Domain.Entities;

namespace HotelBooking.Application.Interfaces;

public interface IHotelRepository : IRepository<Hotel>
{
    Task<IEnumerable<Hotel>> GetHotelsByCityAsync(string city, CancellationToken cancellationToken = default);
    Task<Hotel?> GetHotelWithRoomsAsync(int id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Hotel>> GetAllWithRoomsAsync(CancellationToken cancellationToken = default);
}

