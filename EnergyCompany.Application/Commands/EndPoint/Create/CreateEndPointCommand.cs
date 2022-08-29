using EnergyCompany.Application.Base;

namespace EnergyCompany.Application.Commands.EndPoint.Create;

public class CreateEndPointCommand : ICommandBase<CreateEndPointResponse>
{
    public int SwitchState { get; set; }
    public string SerialNumber { get; set; } = "";
    public string FirmwareVersion { get; set; } = "";
    public int Number { get; set; }
    public string ModelId { get; set; }
}