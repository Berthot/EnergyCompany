namespace EnergyCompany.Application.Base;

public interface IServiceBase<in TRequest, out TResponse> where TRequest : ICommandBase<TResponse>
{
    public TResponse Handle(TRequest command);
}