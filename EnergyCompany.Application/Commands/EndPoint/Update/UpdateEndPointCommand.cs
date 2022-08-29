using EnergyCompany.Application.Base;

namespace EnergyCompany.Application.Commands.EndPoint.Update;

public class UpdateEndPointCommand : ICommandBase<UpdateEndPointResponse>
{
    public string SerialNumber { get; set; } = "";
    public int SwitchState { get; set; }
}