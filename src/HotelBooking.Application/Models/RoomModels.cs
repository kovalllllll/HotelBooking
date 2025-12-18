using HotelBooking.Domain.Enums;

namespace HotelBooking.Application.Models;

public class RoomModel
{
    public int Id { get; set; }
    public string RoomNumber { get; set; } = string.Empty;
    public RoomType RoomType { get; set; }
    public string RoomTypeName => RoomType.ToString();
    public decimal PricePerNight { get; set; }
    public int Capacity { get; set; }
    public string? Description { get; set; }
    public bool IsAvailable { get; set; }
    public string? ImageUrl { get; set; }
    public int HotelId { get; set; }
    public string HotelName { get; set; } = string.Empty;
}

public class CreateRoomModel
{
    public string RoomNumber { get; set; } = string.Empty;
    public RoomType RoomType { get; set; }
    public decimal PricePerNight { get; set; }
    public int Capacity { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public int HotelId { get; set; }
}

public class UpdateRoomModel
{
    public string RoomNumber { get; set; } = string.Empty;
    public RoomType RoomType { get; set; }
    public decimal PricePerNight { get; set; }
    public int Capacity { get; set; }
    public string? Description { get; set; }
    public bool IsAvailable { get; set; }
    public string? ImageUrl { get; set; }
}

public class RoomSearchModel
{
    public string? City { get; set; }
    public DateTime? CheckInDate { get; set; }
    public DateTime? CheckOutDate { get; set; }
    public int? Capacity { get; set; }
    public decimal? MaxPrice { get; set; }
    public RoomType? RoomType { get; set; }
}

