using EnergyCompany.Application.Base;
using EnergyCompany.Application.Commands.EndPoint.Create;
using EnergyCompany.Domain.Entities;
using EnergyCompany.Domain.Exceptions;
using EnergyCompany.Infra.Repositories;

namespace EnergyCompany.Application.Handlers;

public class CreateEndPointHandler : IServiceBase<CreateEndPointCommand, CreateEndPointResponse>
{
    private readonly IEndPointRepository _repo;

    public CreateEndPointHandler(IEndPointRepository repo)
    {
        _repo = repo;
    }

    public CreateEndPointResponse Handle(CreateEndPointCommand command)
    {
        var entity = Map(command);

        InvalidEntityException.When(entity.IsValid() == false, "Entity is not valid.");
        
        var obj = _repo.GetByExpression((x => x.SerialNumber == command.SerialNumber));
        EndPointAlreadyExist.When(obj != default, $"Serial Number: {command.SerialNumber} already exist");
        _repo.Create(entity);
        return new CreateEndPointResponse();
    }

    private static EndPoint Map(CreateEndPointCommand command)
    {
        return new EndPoint(
            serialNumber: command.SerialNumber,
            switchState: command.SwitchState,
            firmwareVersion: command.FirmwareVersion,
            number: command.Number,
            modelId: command.ModelId
        );
    }
}