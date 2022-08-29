using EnergyCompany.Application.Base;
using EnergyCompany.Application.Commands.EndPoint.GetBySerialNumber;
using EnergyCompany.Domain.Exceptions;
using EnergyCompany.Infra.Repositories;

namespace EnergyCompany.Application.Handlers;

public class GetBySerialNumberHandler : IServiceBase<GetBySerialNumberCommand, GetBySerialNumberResponse>
{
    private readonly IEndPointRepository _repo;

    public GetBySerialNumberHandler(IEndPointRepository repo)
    {
        _repo = repo;
    }

    public GetBySerialNumberResponse Handle(GetBySerialNumberCommand command)
    {
        var obj = _repo.GetByExpression(x => x.SerialNumber == command.SerialNumber);

        SerialNumberNotFound.When(obj == default, "Serial number is not found!");

        return new GetBySerialNumberResponse
        {
            SwitchState = obj.ToEState().ToString(),
            SerialNumber = obj.SerialNumber,
            FirmwareVersion = obj.Meter.FirmwareVersion,
            Number = obj.Meter.Number,
            ModelId = obj.Meter.GetModelName()
        };
    }
}