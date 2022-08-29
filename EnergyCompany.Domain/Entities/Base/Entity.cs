namespace EnergyCompany.Domain.Entities.Base;

public class Entity
{
    public Guid Uid { get; set; } = Guid.NewGuid();
}