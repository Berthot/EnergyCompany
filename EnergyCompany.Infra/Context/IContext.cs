using EnergyCompany.Domain.Entities;

namespace EnergyCompany.Infra.Context;

public interface IContext
{
    public List<EndPoint> EndPoints { get; set; }

}