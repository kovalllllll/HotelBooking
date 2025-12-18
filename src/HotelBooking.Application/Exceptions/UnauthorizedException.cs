namespace HotelBooking.Application.Exceptions;

/// <summary>
/// Виключення при невдалій авторизації
/// </summary>
public class UnauthorizedException : AppException
{
    public override int StatusCode => 401;
    public override string ErrorCode => "UNAUTHORIZED";

    public UnauthorizedException(string message = "Необхідна авторизація для виконання цієї дії.") 
        : base(message)
    {
    }
}

