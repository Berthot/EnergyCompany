using EnergyCompany.Application.Base;

namespace EnergyCompany.Application.Commands.EndPoint.GetBySerialNumber;

public class GetBySerialNumberCommand : ICommandBase<List<GetBySerialNumberResponse>>, ICommandBase<GetBySerialNumberResponse>
{
    public string SerialNumber { get; set; } = "";
}