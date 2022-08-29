using EnergyCompany.Application.Base;

namespace EnergyCompany.Application.Commands.EndPoint.Delete;

public class DeleteEndPointCommand : ICommandBase<DeleteEndPointResponse>
{
    public string SerialNumber { get; set; } = "";
}