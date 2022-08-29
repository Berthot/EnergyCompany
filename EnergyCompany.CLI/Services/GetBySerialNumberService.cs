using EnergyCompany.Application.Commands.EndPoint.GetBySerialNumber;
using EnergyCompany.Application.Main;
using EnergyCompany.CLI.Menu;

namespace EnergyCompany.CLI.Services;

public class GetBySerialNumberService
{
    private readonly Mediator _mediator;

    public GetBySerialNumberService(Mediator mediator)
    {
        _mediator = mediator;
    }

    public void GetBySerialNumber()
    {
        var command = new GetBySerialNumberCommand()
        {
            SerialNumber = MenuHelper.ReadValueString("Serial Number"),
        };
        var endPoint = _mediator.GetBySerialNumber(command);

        Console.WriteLine(endPoint);
    }
}