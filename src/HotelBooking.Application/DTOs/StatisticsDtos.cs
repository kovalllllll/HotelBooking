namespace HotelBooking.Application.DTOs;

public class BookingStatisticsDto
{
    public int TotalBookings { get; set; }
    public int ConfirmedBookings { get; set; }
    public int CancelledBookings { get; set; }
    public decimal TotalRevenue { get; set; }
    public List<MonthlyBookingStats> MonthlyStats { get; set; } = [];
    public List<HotelBookingStats> HotelStats { get; set; } = [];
}

public class MonthlyBookingStats
{
    public int Year { get; set; }
    public int Month { get; set; }
    public string MonthName { get; set; } = string.Empty;
    public int BookingsCount { get; set; }
    public decimal Revenue { get; set; }
}

public class HotelBookingStats
{
    public int HotelId { get; set; }
    public string HotelName { get; set; } = string.Empty;
    public int BookingsCount { get; set; }
    public decimal Revenue { get; set; }
    public double OccupancyRate { get; set; }
}

