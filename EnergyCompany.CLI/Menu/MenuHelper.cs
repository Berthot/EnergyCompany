using System.Diagnostics;

namespace EnergyCompany.CLI.Menu;

public static class MenuHelper
{
    private static List<string> GetMenuList() => new List<string>()
    {
        "[1] - Insert a new endpoint.",
        "[2] - Edit an existing endpoint.",
        "[3] - Delete an existing endpoint.",
        "[4] - List all endpoints.",
        "[5] - Find a endpoint by \"Endpoint Serial Number\".",
        "[0] - Exit.",
    };

    public static void ShowMenu()
    {
        PrintLine();
        GetMenuList().ForEach(Console.WriteLine);
        PrintLine();
    }

    private static void PrintLine(int len = 48, char chr = '-')
    {
        var line = "|";
        for (var i = 0; i < len; i++)
            line += chr;
        line += "|";
        Console.WriteLine(line);
    }

    public static int? ReadValue()
    {
        var value = Console.ReadLine() ?? "";
        var valid = int.TryParse(value, out var intValue);
        if(valid == false)
            Console.WriteLine($"Parameter: is a integer, please fill correctly.");
        return intValue;
    }

    public static string ReadValueString(string param)
    {
        Console.WriteLine($"STR: Insert {param}:");
        Console.Write($"Enter with response here: ");
        var value = Console.ReadLine() ?? "";
        return value;
    }
    
    public static int ReadValueInt(string param)
    {
        Console.WriteLine($"INT: Insert {param}:");
        Console.Write($"Enter with response here: ");
        var value = Console.ReadLine() ?? "";
        var valid = int.TryParse(value, out var intValue);
        if(valid == false || intValue <= -1)
            throw new Exception($"Parameter: [{param}] is a integer, please fill correctly.");
        // if (intValue <= 0)
            // throw new Exception("Value not valid.");
        return intValue;
    }

    public static void Exit()
    {
        Console.WriteLine("Are you sure, you want to leave? [y] yes [n] no");
        var response = ReadValueString("[y] or [n]").ToLower().ToList()[0];
        if(response != 'y')
            return;
        Console.WriteLine("bye bye cia!");
        Process.GetCurrentProcess().Kill();
    }
}