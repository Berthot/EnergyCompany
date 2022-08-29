using EnergyCompany.Application.Commands.EndPoint.Delete;
using EnergyCompany.Application.Main;
using EnergyCompany.CLI.Menu;

namespace EnergyCompany.CLI.Services;

public class DeleteEndPointService
{
    private readonly Mediator _mediator;

    public DeleteEndPointService(Mediator mediator)
    {
        _mediator = mediator;
    }

    public void Delete()
    {
        var command = new DeleteEndPointCommand()
        {
            SerialNumber = MenuHelper.ReadValueString("Serial Number"),
        };
        _mediator.DeleteEndPoint(command);
    }
}