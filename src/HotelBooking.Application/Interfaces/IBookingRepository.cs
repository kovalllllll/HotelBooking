using HotelBooking.Domain.Entities;

namespace HotelBooking.Application.Interfaces;

public interface IBookingRepository : IRepository<Booking>
{
    Task<IEnumerable<Booking>> GetBookingsByUserAsync(string userId);
    Task<IEnumerable<Booking>> GetAllBookingsWithDetailsAsync();
    Task<Booking?> GetBookingWithDetailsAsync(int id);
    Task<IEnumerable<Booking>> GetBookingsByRoomAsync(int roomId);
    Task<IEnumerable<Booking>> GetBookingsInDateRangeAsync(DateTime startDate, DateTime endDate);
}

