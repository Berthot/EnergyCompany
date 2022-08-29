namespace EnergyCompany.Domain.Exceptions;

public class ModelNotFoundException : Exception
{
    private const string DefaultMessage = "Model not found";

    public ModelNotFoundException() : base(DefaultMessage)
    {
    }

    public ModelNotFoundException(string message) : base(message)
    {
    }

    public ModelNotFoundException(Exception innerException) : base(DefaultMessage, innerException)
    {
    }

    public ModelNotFoundException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public static void When(bool condition, string message)
    {
        if (condition)
            throw new ModelNotFoundException(message);
    }
}