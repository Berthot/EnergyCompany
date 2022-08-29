using EnergyCompany.Domain.Entities;

namespace EnergyCompany.Infra.Context;

public class Context : IContext
{
    public Context()
    {
        EndPoints = new List<EndPoint>();
    }

    public List<EndPoint> EndPoints { get; set; }
}