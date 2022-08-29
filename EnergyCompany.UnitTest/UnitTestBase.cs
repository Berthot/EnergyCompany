using EnergyCompany.Application.Handlers;
using EnergyCompany.Infra.Repositories;
using NUnit.Framework;

namespace EnergyCompany.UnitTest;

public class UnitTestBase
{
    protected CreateEndPointHandler _createHandler;
    protected EndPointRepository _repo;
    protected FakeContext _fakeContext;

    [SetUp]
    public void SetUp()
    {
        _fakeContext = new FakeContext();
        _repo = new EndPointRepository(_fakeContext);
        _createHandler = new CreateEndPointHandler(_repo);
    }
    
    [TearDown]
    public void TearDown()
    {
        _fakeContext.EndPoints = new();
    }

}