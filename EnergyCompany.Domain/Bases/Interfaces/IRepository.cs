using EnergyCompany.Domain.Entities.Base;

namespace EnergyCompany.Domain.Bases.Interfaces;

public interface IRepository<TEntity> where TEntity : Entity
{
    public List<TEntity> GetAll();
    public void Create(TEntity entity);
    public void Update(TEntity entity);
    public void Delete(Guid id);
    public TEntity GetByExpression(Func<TEntity, bool> condition);
}