using EnergyCompany.Application.Commands.EndPoint.Create;
using EnergyCompany.Application.Main;
using EnergyCompany.CLI.Menu;
using EnergyCompany.Domain.Exceptions;

namespace EnergyCompany.CLI.Services;

public class CreateEndPointService
{
    private readonly Mediator _mediator;

    public CreateEndPointService(Mediator mediator)
    {
        _mediator = mediator;
    }

    public void Create()
    {
        var command = new CreateEndPointCommand()
        {
            SerialNumber = MenuHelper.ReadValueString("Serial Number"),
            SwitchState = SwitchState(),
            FirmwareVersion = MenuHelper.ReadValueString("Firmware Version"),
            Number = MenuHelper.ReadValueInt("Number"),
            ModelId = MenuHelper.ReadValueString("Model Id").ToLower(),
        };
        _mediator.CreateEndPoint(command);
    }

    private static int SwitchState()
    {
        var value = MenuHelper.ReadValueInt("Switch State \n[0] Disconnected \n[1] Connected \n[2] Armed");
        var list = new List<int>() {0, 1, 2};
        MenuInputValueException.When(list.Contains(value) == false, "Choose a valid Switch State [0] Disconnected or [1] Connected or [2] Armed");
        return value;
    }
}