using System.Diagnostics.Metrics;
using EnergyCompany.Application.Commands.EndPoint.Create;
using EnergyCompany.Application.Handlers;
using EnergyCompany.Domain.Entities.ValueObject;
using EnergyCompany.Domain.Exceptions;
using EnergyCompany.Infra.Repositories;
using NUnit.Framework;
using Meter = EnergyCompany.Domain.Entities.ValueObject.Meter;

namespace EnergyCompany.UnitTest.Commands;

public class CreateEndPointTest : UnitTestBase
{
    

    
    [Test]
    [TestCase(0)]
    [TestCase(1)]
    [TestCase(2)]
    public void SWITCH_CASE_INVALID_NOT_THROW(int switchState)
    {
        // Arr
        var command = new CreateEndPointCommand
        {
            SwitchState = switchState,
            SerialNumber = "text",
            FirmwareVersion = "text",
            Number = 3,
            ModelId = "NSX1P3W"
        };
        // Act

        // Ass
        Assert.DoesNotThrow(() => _createHandler.Handle(command));

    }

    [Test]
    [TestCase(3)]
    [TestCase(123)]
    public void SWITCH_CASE_INVALID_THROW_InvalidEntityException(int switchState)
    {
        // Arr
        var command = new CreateEndPointCommand
        {
            SwitchState = switchState,
            SerialNumber = "text",
            FirmwareVersion = "text",
            Number = 3,
            ModelId = "NSX1P3W"
        };
        // Act

        // Ass
        Assert.Throws<InvalidEntityException>(() => _createHandler.Handle(command));

    }


    [Test]
    [TestCase("2.0", 23, "NSX1P2W", 16)]
    [TestCase("2.0", 23, "NSX1P3W", 17)]
    [TestCase("2.0", 23, "NSX2P3W", 18)]
    [TestCase("2.0", 23, "NSX3P4W", 19)]
    public void VALIDATE_MODEL_ID_STR_NOT_THROW_EXCEPTION(string firmwareVersion, int number, string modelString, int shouldBe)
    {
        
        // Arr
        var meter = new Meter(firmwareVersion, number, modelString);
        
        // Act
        meter.IsValid();
        // Ass
        
        Assert.AreEqual(shouldBe, meter.ModelId);
    }
    
    [Test]
    [TestCase("2.0", 23, "NSX1P2W", 16)]
    [TestCase("2.0", 23, "NSX1P3W", 17)]
    [TestCase("2.0", 23, "NSX2P3W", 18)]
    [TestCase("2.0", 23, "NSX3P4W", 19)]
    public void VALIDATE_MODEL_ID_INT_NOT_THROW_EXCEPTION(string firmwareVersion, int number, string modelString, int shouldBe)
    {
        
        // Arr
        var meter = new Meter(firmwareVersion, number, shouldBe);
        
        // Act
        // Ass
        
        Assert.AreEqual(modelString, meter.GetModelName());
    }
}