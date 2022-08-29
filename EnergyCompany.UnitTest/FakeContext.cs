using System.Collections.Generic;
using EnergyCompany.Domain.Entities;
using EnergyCompany.Infra.Context;

namespace EnergyCompany.UnitTest;

public class FakeContext : IContext
{
    public List<EndPoint> EndPoints { get; set; }
    
    public FakeContext()
    {
        EndPoints = new List<EndPoint>();
    }
}