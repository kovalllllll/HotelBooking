namespace HotelBooking.Application.Exceptions;

public class ForbiddenException(string message = "Ви не маєте прав для виконання цієї дії.")
    : AppException(message)
{
    public override int StatusCode => 403;
    public override string ErrorCode => "FORBIDDEN";
}