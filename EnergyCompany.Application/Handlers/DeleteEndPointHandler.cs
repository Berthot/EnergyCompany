using EnergyCompany.Application.Base;
using EnergyCompany.Application.Commands.EndPoint.Delete;
using EnergyCompany.Domain.Exceptions;
using EnergyCompany.Infra.Repositories;

namespace EnergyCompany.Application.Handlers;

public class DeleteEndPointHandler : IServiceBase<DeleteEndPointCommand, DeleteEndPointResponse>
{
    private readonly IEndPointRepository _repo;

    public DeleteEndPointHandler(IEndPointRepository repo)
    {
        _repo = repo;
    }

    public DeleteEndPointResponse Handle(DeleteEndPointCommand command)
    {
        var obj = _repo.GetByExpression((x => x.SerialNumber == command.SerialNumber));
        EndPointAlreadyExist.When(obj == default, $"Serial Number: {command.SerialNumber} not found!");
        _repo.Delete(obj!.Uid);
        return new DeleteEndPointResponse();
    }
}