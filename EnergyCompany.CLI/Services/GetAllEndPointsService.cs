using EnergyCompany.Application.Commands.EndPoint.GetAll;
using EnergyCompany.Application.Main;

namespace EnergyCompany.CLI.Services;

public class GetAllEndPointsService
{
    private readonly Mediator _mediator;

    public GetAllEndPointsService(Mediator mediator)
    {
        _mediator = mediator;
    }

    public void GetAll()
    {
        var command = new GetAllEndPointCommand();
        var endPoints = _mediator.GetAllEndPoints(command);

        foreach (var point in endPoints)
        {
            Console.WriteLine(point.ToString());

        }
    }
}