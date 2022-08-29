using EnergyCompany.Application.Base;
using EnergyCompany.Application.Commands.EndPoint.GetAll;
using EnergyCompany.Infra.Repositories;

namespace EnergyCompany.Application.Handlers;

public class GetAllEndPointsHandler : IServiceBase<GetAllEndPointCommand, List<GetAllEndPointResponse>>
{
    private readonly IEndPointRepository _repo;

    public GetAllEndPointsHandler(IEndPointRepository repo)
    {
        _repo = repo;
    }

    public List<GetAllEndPointResponse> Handle(GetAllEndPointCommand command)
    {
        var all = _repo.GetAll();
        
        return all.Select(x => new GetAllEndPointResponse
        {
            Uid = x.Uid,
            SwitchState = x!.ToEState().ToString(),
            SerialNumber = x.SerialNumber,
            FirmwareVersion = x.Meter.FirmwareVersion,
            Number = x.Meter.Number,
            ModelId = x.Meter.GetModelName()
        }).ToList();
        
    }
}