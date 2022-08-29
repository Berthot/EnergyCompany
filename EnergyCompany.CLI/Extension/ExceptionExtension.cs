namespace EnergyCompany.CLI.Extension;

public static class ExceptionExtension
{
    public static void ShowMessageError(this Exception ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"ERR: {ex.Message}");
        Console.ResetColor();
    }
}