namespace HotelBooking.Application.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IHotelRepository Hotels { get; }
    IRoomRepository Rooms { get; }
    IBookingRepository Bookings { get; }
    Task<int> SaveChangesAsync();
}

