namespace EnergyCompany.Domain.Exceptions;

public class EndPointAlreadyExist : Exception
{
    private const string DefaultMessage = "EndPoint already exist";

    public EndPointAlreadyExist() : base(DefaultMessage)
    {
    }

    public EndPointAlreadyExist(string message) : base(message)
    {
    }

    public EndPointAlreadyExist(Exception innerException) : base(DefaultMessage, innerException)
    {
    }

    public EndPointAlreadyExist(string message, Exception innerException) : base(message, innerException)
    {
    }

    public static void When(bool condition, string message)
    {
        if (condition)
            throw new EndPointAlreadyExist(message);
    }
}