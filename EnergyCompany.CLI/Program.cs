using EnergyCompany.Application;
using EnergyCompany.CLI.Menu;
using EnergyCompany.CLI.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EnergyCompany.CLI;

public class Program
{
    public static void Main(string[] args)
    {
        var serviceProvider = DependencyInjection();
        var service = serviceProvider.GetService<Service>()!;

        while (true)
        {
            MenuHelper.ShowMenu();
            Console.Write("Choose your option: ");
            var value = MenuHelper.ReadValue();
            if (value == null)
            {
                Console.Clear();
                continue;
            }

            var selected = value.Value;

            switch (selected)
            {
                case 1:
                    service.Create();
                    EndMethod();
                    break;
                case 2:
                    service.Update();
                    EndMethod();
                    break;
                case 3:
                    service.Delete();
                    EndMethod();
                    break;
                case 4:
                    service.GetAll();
                    EndMethod();
                    break;
                case 5:
                    service.GetById();
                    EndMethod();
                    break;
                case 0:
                    MenuHelper.Exit();
                    EndMethod();
                    break;
                default:
                    Console.WriteLine("bye bye cia!");
                    break;
            }
        }

        // ReSharper disable once FunctionNeverReturns
    }

    private static void EndMethod()
    {
        Console.ReadKey();
        Console.Clear();
    }

    private static ServiceProvider DependencyInjection()
    {
        var serviceProvider = new ServiceCollection()
            .AddLogging()
            .ApplicationDependencyInjection()
            .AddTransient<CreateEndPointService>()
            .AddTransient<UpdateEndPointService>()
            .AddTransient<DeleteEndPointService>()
            .AddTransient<GetAllEndPointsService>()
            .AddTransient<GetBySerialNumberService>()
            .AddTransient<Service>()
            .BuildServiceProvider();
        return serviceProvider;
    }
}