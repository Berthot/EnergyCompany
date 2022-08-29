using EnergyCompany.Domain.Exceptions;

namespace EnergyCompany.Domain.Entities.ValueObject;

public class Meter
{
    public Meter(string firmwareVersion, int number, int modelId)
    {
        FirmwareVersion = firmwareVersion;
        Number = number;
        ModelId = modelId;
    }
    
    public Meter(string firmwareVersion, int number, string modelString)
    {
        FirmwareVersion = firmwareVersion;
        Number = number;
        ModelString = modelString;
    }


    public string FirmwareVersion { get; set; } = "";
    public int Number { get; set; }
    public int ModelId { get; set; }
    private string ModelString { get; set; }

    public string GetModelName()
    {
        return (int) ModelId switch
        {
            16 => "nsx1p2w".ToUpper(),
            17 => "nsx1p3w".ToUpper(),
            18 => "nsx2p3w".ToUpper(),
            19 => "nsx3p4w".ToUpper(),
            _ => throw new ModelNotFoundException()
        };
    }

    private int GetModelInt(string input)
    {
        var data = input.ToLower();
        return (string) data switch
        {
            "nsx1p2w" => 16,
            "nsx1p3w" => 17,
            "nsx2p3w" => 18,
            "nsx3p4w" => 19,
            _ => throw new ModelNotFoundException($"Model [{input}] was not identify")
        };
    }

    public bool IsValid()
    {
        ModelId = GetModelInt(ModelString);
        return true;
    }
}