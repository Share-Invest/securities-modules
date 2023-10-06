namespace ShareInvest.Services;

public interface IEventHandler<T>
{
    event EventHandler<T> Send;
}