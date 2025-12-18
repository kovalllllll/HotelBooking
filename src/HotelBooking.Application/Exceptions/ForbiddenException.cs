namespace HotelBooking.Application.Exceptions;

/// <summary>
/// Виключення при відсутності прав доступу
/// </summary>
public class ForbiddenException : AppException
{
    public override int StatusCode => 403;
    public override string ErrorCode => "FORBIDDEN";

    public ForbiddenException(string message = "Ви не маєте прав для виконання цієї дії.") 
        : base(message)
    {
    }
}

