using EnergyCompany.Application.Commands.EndPoint.Create;
using EnergyCompany.Application.Commands.EndPoint.Delete;
using EnergyCompany.Application.Commands.EndPoint.GetAll;
using EnergyCompany.Application.Commands.EndPoint.GetBySerialNumber;
using EnergyCompany.Application.Commands.EndPoint.Update;
using EnergyCompany.Application.Handlers;

namespace EnergyCompany.Application.Main;

public class Mediator
{
    private readonly CreateEndPointHandler _createEndPointHandler;
    private readonly UpdateEndPointHandler _updateEndPointHandler;
    private readonly DeleteEndPointHandler _deleteEndPointHandler;
    private readonly GetAllEndPointsHandler _getAllEndPointHandler;
    private readonly GetBySerialNumberHandler _getBySerialNumber;

    public Mediator(CreateEndPointHandler createEndPointHandler, UpdateEndPointHandler updateEndPointHandler, DeleteEndPointHandler deleteEndPointHandler, GetAllEndPointsHandler getAllEndPointHandler, GetBySerialNumberHandler getBySerialNumber)
    {
        _createEndPointHandler = createEndPointHandler;
        _updateEndPointHandler = updateEndPointHandler;
        _deleteEndPointHandler = deleteEndPointHandler;
        _getAllEndPointHandler = getAllEndPointHandler;
        _getBySerialNumber = getBySerialNumber;
    }

    public void CreateEndPoint(CreateEndPointCommand command)
    {
        try
        {
            var response = _createEndPointHandler.Handle(command);
            Console.WriteLine($"SUCCESS: {response.Status}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"ERROR: {e.Message}");
        }
    }
    
    public void UpdateEndPoint(UpdateEndPointCommand command)
    {
        try
        {
            var response = _updateEndPointHandler.Handle(command);
            Console.WriteLine($"SUCCESS: {response.Status}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"ERROR: {e.Message}");
        }
    }

    public void DeleteEndPoint(DeleteEndPointCommand command)
    {
        try
        {
            var response = _deleteEndPointHandler.Handle(command);
            Console.WriteLine($"SUCCESS: {response.Status}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"ERROR: {e.Message}");
        }
    }

    public List<GetAllEndPointResponse> GetAllEndPoints(GetAllEndPointCommand command)
    {
        try
        {
            return _getAllEndPointHandler.Handle(command);
        }
        catch (Exception e)
        {
            Console.WriteLine($"ERROR: {e.Message}");
        }

        return new List<GetAllEndPointResponse>();
    }

    public GetBySerialNumberResponse GetBySerialNumber(GetBySerialNumberCommand command)
    {
        try
        {
            var response = _getBySerialNumber.Handle(command);
            return response;
        }
        catch (Exception e)
        {
            Console.WriteLine($"ERROR: {e.Message}");
        }

        return null;
    }
}