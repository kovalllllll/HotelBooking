using HotelBooking.Application.DTOs;

namespace HotelBooking.Application.Interfaces;

public interface IBookingService
{
    Task<IEnumerable<BookingDto>> GetAllBookingsAsync();
    Task<BookingDto?> GetBookingByIdAsync(int id);
    Task<IEnumerable<BookingDto>> GetUserBookingsAsync(string userId);
    Task<BookingDto> CreateBookingAsync(string userId, CreateBookingDto dto);
    Task<BookingDto?> UpdateBookingStatusAsync(int id, UpdateBookingStatusDto dto);
    Task<bool> CancelBookingAsync(int id, string userId);
}

