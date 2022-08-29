namespace EnergyCompany.Domain.Exceptions;

public class InvalidEntityException : Exception
{
    private const string DefaultMessage = "Entity is not valid";

    public InvalidEntityException() : base(DefaultMessage)
    {
    }

    public InvalidEntityException(string message) : base(message)
    {
    }

    public InvalidEntityException(Exception innerException) : base(DefaultMessage, innerException)
    {
    }

    public InvalidEntityException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public static void When(bool condition, string message)
    {
        if (condition)
            throw new InvalidEntityException(message);
    }
}