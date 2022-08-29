using EnergyCompany.Domain.Entities;
using EnergyCompany.Infra.Context;

namespace EnergyCompany.Infra.Repositories;

public class EndPointRepository : IEndPointRepository
{
    private readonly IContext _context;

    public EndPointRepository(IContext context)
    {
        _context = context;
    }

    public void Create(EndPoint entity)
    {
        _context.EndPoints.Add(entity);
    }

    public List<EndPoint> GetAll()
    {
        return _context.EndPoints.ToList();
    }

    public void Update(EndPoint entity)
    {
        _context.EndPoints.RemoveAll(x => x.SerialNumber == entity.SerialNumber);
        _context.EndPoints.Add(entity);
    }

    public void Delete(Guid id)
    {
        _context.EndPoints.RemoveAll(x => x.Uid == id);
    }

    public EndPoint GetByExpression(Func<EndPoint, bool> condition)
    {
        return _context.EndPoints.FirstOrDefault(condition)!;
    }
}