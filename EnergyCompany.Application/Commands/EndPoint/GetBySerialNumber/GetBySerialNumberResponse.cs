namespace EnergyCompany.Application.Commands.EndPoint.GetBySerialNumber;

public class GetBySerialNumberResponse
{
    public string SwitchState { get; set; } = "";
    public string SerialNumber { get; set; } = "";
    public string FirmwareVersion { get; set; } = "";
    public int Number { get; set; }
    public string ModelId { get; set; } = "";

    public override string ToString()
    {
        return "<><><><><><><><><><><><><><><><><><><><><><><><><>" +
               "\nNumber          : " + Number +
               "\nFirmwareVersion : " + FirmwareVersion +
               "\nModelId         : " + ModelId +
               "\nSerialNumber    : " + SerialNumber +
               "\nSwitchState     : " + SwitchState +
               "\n<><><><><><><><><><><><><><><><><><><><><><><><>";
    }
}