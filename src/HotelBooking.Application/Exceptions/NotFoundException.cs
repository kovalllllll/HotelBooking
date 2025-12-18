namespace HotelBooking.Application.Exceptions;

public class NotFoundException : AppException
{
    public override int StatusCode => 404;
    public override string ErrorCode => "NOT_FOUND";

    public NotFoundException(string message) : base(message)
    {
    }

    public NotFoundException(string entityName, object key)
        : base($"{entityName} з ідентифікатором '{key}' не знайдено.")
    {
    }
}