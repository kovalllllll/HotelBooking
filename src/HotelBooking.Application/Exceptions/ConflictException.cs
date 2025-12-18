namespace HotelBooking.Application.Exceptions;

/// <summary>
/// Виключення при конфлікті даних
/// </summary>
public class ConflictException : AppException
{
    public override int StatusCode => 409;
    public override string ErrorCode => "CONFLICT";

    public ConflictException(string message) : base(message)
    {
    }
}

