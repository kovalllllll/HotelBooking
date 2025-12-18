using HotelBooking.Application.DTOs;

namespace HotelBooking.Application.Interfaces;

public interface IStatisticsRepository
{
    Task<BookingStatisticsDto> GetBookingStatisticsAsync(DateTime? startDate = null, DateTime? endDate = null);
}

