using EnergyCompany.Domain.Entities.Base;
using EnergyCompany.Domain.Entities.ValueObject;
using EnergyCompany.Domain.Enums;
using EnergyCompany.Domain.Exceptions;

namespace EnergyCompany.Domain.Entities;

public class EndPoint : Entity
{
    public EndPoint(string serialNumber, int switchState, string firmwareVersion, int number, int modelId)
    {
        SerialNumber = serialNumber;
        Meter = new Meter(firmwareVersion, number, modelId);
        SwitchState = switchState;
    }

    public EndPoint(string serialNumber, int switchState, string firmwareVersion, int number, string modelId)
    {
        SerialNumber = serialNumber;
        Meter = new Meter(firmwareVersion, number, modelId);
        SwitchState = switchState;
    }

    public string SerialNumber { get; set; }
    public Meter Meter { get; set; }
    public int SwitchState { get; set; }

    public EState ToEState()
    {
        return (EState) SwitchState;
    }

    public void ChangeStateTo(EState state)
    {
        SwitchState = (int) state;
    }

    public bool IsValid()
    {
        var list = new List<bool>()
        {
            ValidateSwitchState(),
            Meter.IsValid(),
            string.IsNullOrEmpty(SerialNumber) is false
        };
        return list.All(x => x == true);
    }

    private bool ValidateSwitchState()
    {
        InvalidEntityException.When((SwitchState >= 0 && SwitchState <= 2) == false, $"SwitchState is not valid [{SwitchState}]");
        return true;
    }
}