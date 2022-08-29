using EnergyCompany.Application.Base;
using EnergyCompany.Application.Commands.EndPoint.Update;
using EnergyCompany.Domain.Exceptions;
using EnergyCompany.Infra.Repositories;

namespace EnergyCompany.Application.Handlers;

public class UpdateEndPointHandler : IServiceBase<UpdateEndPointCommand, UpdateEndPointResponse>
{
    private readonly IEndPointRepository _repo;

    public UpdateEndPointHandler(IEndPointRepository repo)
    {
        _repo = repo;
    }


    public UpdateEndPointResponse Handle(UpdateEndPointCommand command)
    {
        var obj = _repo.GetByExpression((x => x.SerialNumber == command.SerialNumber));
        EndPointAlreadyExist.When(obj == default, $"Serial Number: {command.SerialNumber} not found!");

        if (obj!.SwitchState == command.SwitchState)
            return new UpdateEndPointResponse();
        obj.SwitchState = command.SwitchState;

        InvalidEntityException.When(obj.IsValid() == false, "Entity: SwitchState is not valid!");

        _repo.Update(obj);
        
        
        return new UpdateEndPointResponse();
    }
}