using EnergyCompany.CLI.Extension;

namespace EnergyCompany.CLI.Services;

public class Service
{
    private readonly CreateEndPointService _createService;
    private readonly UpdateEndPointService _update;
    private readonly DeleteEndPointService _delete;
    private readonly GetAllEndPointsService _getAll;
    private readonly GetBySerialNumberService _getBySerialNumber;

    public Service(CreateEndPointService create, UpdateEndPointService update, DeleteEndPointService delete, GetAllEndPointsService getAll, GetBySerialNumberService getBySerialNumber)
    {
        _createService = create;
        _update = update;
        _delete = delete;
        _getAll = getAll;
        _getBySerialNumber = getBySerialNumber;
    }


    public void Create()
    {
        try
        {
            _createService.Create();
        }
        catch (Exception e)
        {
            e.ShowMessageError();
        }
    }

    public void Update()
    {
        try
        {
            _update.Update();
        }
        catch (Exception e)
        {
            e.ShowMessageError();
        }
    }

    public void Delete()
    {
        try
        {
            _delete.Delete();
        }
        catch (Exception e)
        {
            e.ShowMessageError();
        }
    }

    public void GetAll()
    {
        try
        {
            _getAll.GetAll();
        }
        catch (Exception e)
        {
            e.ShowMessageError();
        }
    }

    public void GetById()
    {
        try
        {
            _getBySerialNumber.GetBySerialNumber();
        }
        catch (Exception e)
        {
            e.ShowMessageError();
        }
    }

}