namespace Goodreads.Business.Service.Interface;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}