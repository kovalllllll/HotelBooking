using HotelBooking.Application.DTOs;

namespace HotelBooking.Application.Interfaces;

public interface IHotelService
{
    Task<IEnumerable<HotelDto>> GetAllHotelsAsync();
    Task<HotelDto?> GetHotelByIdAsync(int id);
    Task<IEnumerable<HotelDto>> GetHotelsByCityAsync(string city);
    Task<HotelDto> CreateHotelAsync(CreateHotelDto dto);
    Task<HotelDto?> UpdateHotelAsync(int id, UpdateHotelDto dto);
    Task<bool> DeleteHotelAsync(int id);
}
