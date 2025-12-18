namespace HotelBooking.Application.Exceptions;

public class UnauthorizedException(string message = "Необхідна авторизація для виконання цієї дії.")
    : AppException(message)
{
    public override int StatusCode => 401;
    public override string ErrorCode => "UNAUTHORIZED";
}