namespace EnergyCompany.CLI.Menu;

public class MenuOptionNotFoundException : Exception
{
    private const string DefaultMessage = "Menu Option not found";

    public MenuOptionNotFoundException() : base(DefaultMessage)
    {
    }

    public MenuOptionNotFoundException(string message) : base(message)
    {
    }

    public MenuOptionNotFoundException(Exception innerException) : base(DefaultMessage, innerException)
    {
    }

    public MenuOptionNotFoundException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public static void When(bool condition, string? message = null)
    {
        if (condition)
            throw new MenuOptionNotFoundException(message ?? DefaultMessage);
    }
}