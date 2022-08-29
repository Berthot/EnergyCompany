namespace EnergyCompany.Domain.Exceptions;

public class SerialNumberNotFound : Exception
{
    private const string DefaultMessage = "Model not found";

    public SerialNumberNotFound() : base(DefaultMessage)
    {
    }

    public SerialNumberNotFound(string message) : base(message)
    {
    }

    public SerialNumberNotFound(Exception innerException) : base(DefaultMessage, innerException)
    {
    }

    public SerialNumberNotFound(string message, Exception innerException) : base(message, innerException)
    {
    }

    public static void When(bool condition, string message)
    {
        if (condition)
            throw new SerialNumberNotFound(message);
    }
}