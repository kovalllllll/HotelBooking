using HotelBooking.Domain.Enums;

namespace HotelBooking.Application.Models;

public class BookingModel
{
    public int Id { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public decimal TotalPrice { get; set; }
    public BookingStatus Status { get; set; }
    public string StatusName => Status.ToString();
    public string? SpecialRequests { get; set; }
    public int NumberOfGuests { get; set; }
    public int RoomId { get; set; }
    public string RoomNumber { get; set; } = string.Empty;
    public string HotelName { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty;
    public string UserEmail { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}

public class CreateBookingModel
{
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public string? SpecialRequests { get; set; }
    public int NumberOfGuests { get; set; }
    public int RoomId { get; set; }
}

public class UpdateBookingStatusModel
{
    public BookingStatus Status { get; set; }
}

