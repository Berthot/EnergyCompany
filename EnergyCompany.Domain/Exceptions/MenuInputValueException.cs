namespace EnergyCompany.Domain.Exceptions;

public class MenuInputValueException: Exception
{
    private const string DefaultMessage = "EndPoint already exist";

    public MenuInputValueException() : base(DefaultMessage)
    {
    }

    public MenuInputValueException(string message) : base(message)
    {
    }

    public MenuInputValueException(Exception innerException) : base(DefaultMessage, innerException)
    {
    }

    public MenuInputValueException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public static void When(bool condition, string message)
    {
        if (condition)
            throw new MenuInputValueException(message);
    }
}