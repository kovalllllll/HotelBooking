using HotelBooking.Application.DTOs;

namespace HotelBooking.Application.Interfaces;

public interface IRoomService
{
    Task<IEnumerable<RoomDto>> GetAllRoomsAsync();
    Task<RoomDto?> GetRoomByIdAsync(int id);
    Task<IEnumerable<RoomDto>> GetRoomsByHotelAsync(int hotelId);
    Task<IEnumerable<RoomDto>> SearchRoomsAsync(RoomSearchDto searchDto);
    Task<RoomDto> CreateRoomAsync(CreateRoomDto dto);
    Task<RoomDto?> UpdateRoomAsync(int id, UpdateRoomDto dto);
    Task<bool> DeleteRoomAsync(int id);
}

